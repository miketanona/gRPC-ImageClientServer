// ImageProcessorServer.cpp

#include "imageprocessor.grpc.pb.h"
#include <grpcpp/grpcpp.h>
#include <opencv2/opencv.hpp>
#include <iostream>

using grpc::Server;
using grpc::ServerBuilder;
using grpc::ServerContext;
using grpc::Status;

using imageprocessor::ImageRequest;
using imageprocessor::ImageReply;
using imageprocessor::ImageProcessor;

class ImageProcessorServiceImpl final : public ImageProcessor::Service
{
public:
    Status ProcessImage(ServerContext* context,
        const ImageRequest* request,
        ImageReply* response) override
    {

        // Decode the input image
        std::vector<uchar> input_data(request->image_data().begin(), request->image_data().end());
        cv::Mat input_img = cv::imdecode(input_data, cv::IMREAD_COLOR);
        if (input_img.empty())
        {
            return Status(grpc::StatusCode::INVALID_ARGUMENT, "Image decoding failed.");
        }


        // Apply transformation based on the operation
        cv::Mat output_img;
        const std::string& op = request->operation();

        if (op == "grayscale")
        {
            cv::cvtColor(input_img, output_img, cv::COLOR_BGR2GRAY);
        }
        else if (op == "blur")
        {
            //cv::GaussianBlur(input_img, output_img, cv::Size(7, 7), 1.5);
            cv::GaussianBlur(input_img, output_img, cv::Size(15, 15), 0);
        }
        else if (op == "edge")
        {
            cv::Mat gray;
            cv::cvtColor(input_img, gray, cv::COLOR_BGR2GRAY);
            cv::Canny(gray, output_img, 100, 200);
            //cv::Canny(gray, output_img, 150, 250);
        }
        else
        {
            return Status(grpc::StatusCode::INVALID_ARGUMENT, "Unknown operation");
        }



        // Encode output image to JPEG
        std::vector<uchar> encoded;
        cv::imencode(".jpg", output_img, encoded);

        response->set_processed_image(std::string(encoded.begin(), encoded.end()));

        return Status::OK;
    }
};

void RunServer()
{
    std::string server_address("0.0.0.0:50051");
    ImageProcessorServiceImpl service;

    ServerBuilder builder;
    builder.AddListeningPort(server_address, grpc::InsecureServerCredentials());
    builder.RegisterService(&service);

    std::unique_ptr<Server> server(builder.BuildAndStart());
    std::cout << "Server listening on " << server_address << std::endl;
    server->Wait();
}

int main()
{
    RunServer();
    return 0;
}
