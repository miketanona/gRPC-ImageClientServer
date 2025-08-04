# Image Processor with gRPC

A C#/.NET Client and C++ gRPC Server.  The Client app loads a local image, and sends it to the server via gRPC which transforms the image using OpenCV based on user selection (grayscale, blur, or edge), and redisplays the image in the adjacent image box.

## 📁 Project Structure

```
googleRPCv2/
├── ImageProcessorServer/           # C++ gRPC server (uses OpenCV)
├── ImageProcessorProtoLib/         # Static lib for proto-generated gRPC C++ code
├── ImageProcessorCSharpClient/     # Standalone C# WinForms client
├── protos/                         # .proto definitions
└── README.md
```

- `ImageProcessorServer` and `ImageProcessorProtoLib` are in the same Visual Studio solution.
- `ImageProcessorCSharpClient` is a standalone C# project.

---

## ⚙️ Functionality

- Accepts image files and sends them over gRPC.
- Server applies one of three transformations using OpenCV:
  - Grayscale
  - Blur
  - Edge detection
- Transformed image is returned and displayed in the client.

---

## 🖥️ Prerequisites

- Visual Studio 2022
- .NET SDK (for C# client)
- [OpenCV 4.8+](https://opencv.org/releases/) installed to `C:\OpenCV`
- [vcpkg](https://github.com/microsoft/vcpkg) installed to `C:\vcpkg`

---

## 🚧 .gitignore Notes

The repository **excludes**:
- OpenCV (`C:\OpenCV`)
- vcpkg (`C:\vcpkg`)
- Visual Studio intermediate files (`x64/`, `Debug/`, `Release/`)

---

## 🧪 Build Instructions

### 🖼️ ImageProcessorCSharpClient

1. Open `ImageProcessorCSharpClient.sln` in Visual Studio.
2. Ensure NuGet restores `Grpc.Net.Client`.
3. Build and run.
4. Use the GUI to:
   - Load an image.
   - Select an operation from dropdown.
   - Send to the gRPC server.
   - View the result in the second image box.
---

### 🧰 ImageProcessorServer + ProtoLib (C++)

1. Open the solution in `ImageProcessorServer` folder.
2. Ensure the following dependencies are configured:
   - Include: `C:\vcpkg\installed\x64-windows\include`
   - Libs: `C:\vcpkg\installed\x64-windows\lib`
   - OpenCV include: `C:\OpenCV\build\include`
   - OpenCV lib: `C:\OpenCV\build\x64\vc16\lib`
3. Build `ImageProcessorProtoLib` first.
4. Build and run `ImageProcessorServer`.
   - Listens by default on `localhost:50051`.

---

## ⚙️ Setup Instructions

These steps can be done using **PowerShell** or **Git Bash**. (We’ll show PowerShell.)

---

### 📦 Install vcpkg

```powershell
git clone https://github.com/microsoft/vcpkg.git C:\vcpkg
cd C:\vcpkg
.\bootstrap-vcpkg.bat
```

Install dependencies:

```powershell
.\vcpkg install grpc protobuf opencv4:x64-windows
```

---

### 📷 Install OpenCV (C:\OpenCV)

1. Download the OpenCV Windows installer from:
   👉 https://github.com/opencv/opencv/releases
2. Extract it to `C:\OpenCV`
3. Add these to your project settings:
   - Include: `C:\OpenCV\build\include`
   - Libs: `C:\OpenCV\build\x64\vc16\lib`
   - DLLs (runtime): `C:\OpenCV\build\x64\vc16\bin` → Add to PATH

---

## ✅ Tips

- Run the server first (`ImageProcessorServer.exe`).
- Then start your desired client.
- Use PNG or JPG files.
- Output will be saved or displayed depending on client.

---

## 📜 License

MIT License