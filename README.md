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
|  --help   |  无   |  否   |                         |   展示帮助屏幕    |
| --version |  无   |  否   |                         |   显示版本信息    |

## 构建

运行`dotnet build`以构建

[Real-ESRGAN]: https://github.com/xinntao/Real-ESRGAN
