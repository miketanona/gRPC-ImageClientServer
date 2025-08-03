namespace ImageProcessorCSharpClient
{
    partial class GRPC_Client
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnTransform = new Button();
            pbLocalFile = new PictureBox();
            pbGRPC = new PictureBox();
            btnLoad = new Button();
            cbOptions = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pbLocalFile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbGRPC).BeginInit();
            SuspendLayout();
            // 
            // btnTransform
            // 
            btnTransform.Location = new Point(474, 338);
            btnTransform.Name = "btnTransform";
            btnTransform.Size = new Size(75, 23);
            btnTransform.TabIndex = 0;
            btnTransform.Text = "Transform";
            btnTransform.UseVisualStyleBackColor = true;
            btnTransform.Click += button1_Click;
            // 
            // pbLocalFile
            // 
            pbLocalFile.BorderStyle = BorderStyle.FixedSingle;
            pbLocalFile.Location = new Point(12, 19);
            pbLocalFile.Name = "pbLocalFile";
            pbLocalFile.Size = new Size(380, 300);
            pbLocalFile.SizeMode = PictureBoxSizeMode.Zoom;
            pbLocalFile.TabIndex = 1;
            pbLocalFile.TabStop = false;
            // 
            // pbGRPC
            // 
            pbGRPC.BorderStyle = BorderStyle.FixedSingle;
            pbGRPC.Location = new Point(408, 19);
            pbGRPC.Name = "pbGRPC";
            pbGRPC.Size = new Size(380, 300);
            pbGRPC.SizeMode = PictureBoxSizeMode.Zoom;
            pbGRPC.TabIndex = 2;
            pbGRPC.TabStop = false;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(147, 345);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 23);
            btnLoad.TabIndex = 3;
            btnLoad.Text = "Load";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // cbOptions
            // 
            cbOptions.FormattingEnabled = true;
            cbOptions.Location = new Point(598, 341);
            cbOptions.Name = "cbOptions";
            cbOptions.Size = new Size(121, 23);
            cbOptions.TabIndex = 4;
            // 
            // GRPC_Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 421);
            Controls.Add(cbOptions);
            Controls.Add(btnLoad);
            Controls.Add(pbGRPC);
            Controls.Add(pbLocalFile);
            Controls.Add(btnTransform);
            Name = "GRPC_Client";
            Text = "gRPC Transformer";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pbLocalFile).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbGRPC).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnTransform;
        private PictureBox pbLocalFile;
        private PictureBox pbGRPC;
        private Button btnLoad;
        private ComboBox cbOptions;
    }
}
