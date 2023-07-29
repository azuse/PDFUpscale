# PDFUpscale

基于 [Real-ESRGAN] 的 PDF 图像超分辨率命令行程序。

## 参数

|   参数    | 缩写  | 必需  |          默认           |       功能        |
| :-------: | :---: | :---: | :---------------------: | :---------------: |
|  --input  |  -i   |  是   |                         | 输入 PDF 文件(夹) |
| --output  |  -o   |  是   |                         | 输出 PDF 文件(夹) |
|  --model  |  -m   |  否   | realesrgan-x4plus-anime |    使用的模型     |
|  --scale  |  -s   |  否   |            4            |     放大倍数      |
|   --gpu   |  -g   |  否   |          auto           |   使用 GPU 序号   |
| --thread  |  -t   |  否   |            1            |  图片处理并发数   |
|  --help   |  无   |  否   |                         |   展示帮助屏幕    |
| --version |  无   |  否   |                         |   显示版本信息    |

## 运行时

在非 Windows 平台运行本程序需要 libgpilus。

macOS:
```bash
brew install glib cairo libexif libjpeg giflib libtiff autoconf libtool automake pango pkg-config
brew link gettext --
```

基于 Debian 的 Linux:
```bash
sudo apt-get install libgif-dev autoconf libtool automake build-essential gettext libglib2.0-dev libcairo2-dev libtiff-dev libexif-dev
```

## 构建

运行`dotnet build`以构建

[Real-ESRGAN]: https://github.com/xinntao/Real-ESRGAN
