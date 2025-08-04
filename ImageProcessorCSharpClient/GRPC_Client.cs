
using System;
using System.IO;
using System.Windows.Forms;
using Google.Protobuf;
using Grpc.Net.Client;
using Imageprocessor;


namespace ImageProcessorCSharpClient
{
    public partial class GRPC_Client : Form
    {

        private string selectedImagePath = null;
        private byte[] originalImageBytes = null;

        public GRPC_Client()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbOptions.Items.AddRange(new string[] { "grayscale", "blur", "edge" });
            cbOptions.SelectedIndex = 0;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (originalImageBytes == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            string operation = cbOptions.SelectedItem?.ToString() ?? "grayscale";

            try
            {
                using var channel = GrpcChannel.ForAddress("http://localhost:50051");
                var client = new ImageProcessor.ImageProcessorClient(channel);

                var request = new ImageRequest
                {
                    Operation = operation,
                    ImageData = ByteString.CopyFrom(originalImageBytes)
                };

                var response = await client.ProcessImageAsync(request);

                using var ms = new MemoryStream(response.ProcessedImage.ToByteArray());
                pbGRPC.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "gRPC Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp",
                Title = "Select an Image"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedImagePath = ofd.FileName;
                originalImageBytes = File.ReadAllBytes(selectedImagePath);
                pbLocalFile.Image = Image.FromFile(selectedImagePath);
            }
        }

    }

}
