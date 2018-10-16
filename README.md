# file-service
一个基于ASP.NET Core的可伸缩、通用的文件服务器。  
通常后端项目可能会有头像、图片、音频、视频等上传/下载需求，这些需求都可以抽象为文件服务。

## 功能特点
* 支持Linux（推荐）、Windows
* 可伸缩式架构，支持部署1-N台文件服务器
* RESTful架构的API接口，支持多语言客户端
* 支持文件秒传、断点续传、远程拉取上传
* 支持为用户指定磁盘空间配额
* 支持自定义文件处理器

## 系统架构
![Scheme](https://raw.githubusercontent.com/md-frank/file-service/master/doc/fs-scheme.jpg)

* 文件的上传/下载通常由客户端直接与文件服务器交互，上传时需要提供代表用户身份token（由业务服务器生成），成功后会返回文件根地址。  
* 也可以直接由业务服务器上传返回文件根地址给客户端。
* 源码中包含基于.Net Standard的服务端SDK，可以生成token、上传文件等
* 源码中包含基于.Net Standard的客户端SDK，可以上传/下载文件等

## 后端使用

配置业务服务器
```
//Startup.cs代码片段
public void ConfigureServices(IServiceCollection services)
{
    //....
    services.AddFileService(opts =>
    {
        opts.Host = "fs.mondol.info"; //文件服务器域名
        opts.AppSecret = "xxxxxx"; //加密密钥，需要与文件服务器相同
    });
}
```

生成访问令牌
```
IFileServiceManager fileSvceMgr; //此实例可通过DI框架获得
//根据业务规定其意义，例如：1-代表管理员，2-代表用户
var ownerType = 2;
var ownerId = 2; //如果ownerType=2，则为用户ID
var validTime = TimeSpan.FromDays(2); //token有效期
var ownerToken = fileSvceMgr.GenerateOwnerTokenString(ownerType, ownerId, validTime);
```

## 前端使用
文件上传
```
IFileServiceClient fileClient; //此实例可通过DI框架获得
var ownerToken = "业务服务器返回的token";
var periodMinute = 0; //有效期，0不过期
var updResult = await fileClient.UploadAsync(ownerToken, "文件路径", periodMinute);
var url = updResult.Data.Url; //得到文件根地址
```

## URL格式说明
完整URL格式是这样的：`https://domain.com/{fileToken}/{handler}/{modifier}`  
`fileToken`：是本次上传文件的唯一标识符  
`handler`：文件处理器，可以是image(图片处理器)、video(视频处理器)、raw(返回原文件)等  
`modifier`：【可选】文件处理器参数，例如，image处理器，可以指定128x128_png  

文件上传成功后返回的`文件根地址(updResult.Data.Url)`就是截至到https://domain.com/{fileToken}，URL后面部分由客户端自己去拼接  

### 下面举例说明：  

下载原文件  
文件根地址/raw，例如：  
`http://file.domain.com/files/1iYQTU7fEUgaa~URSVwaCqQKFml_IAAAAAgAAAAbhmsFjiUUQwCPn2ngI1QcvsSp0AA/raw`

下载128x128大小的缩略图（原文件是图像）  
文件根地址/image/128x128，例如：
`http://file.domain.com/files/1iYQTU7fEUgaa~URSVwaCqQKFml_IAAAAAgAAAAbhmsFjiUUQwCPn2ngI1QcvsSp0AA/image/128x128`

下载128宽，高等比缩放的缩略图（原文件是图像）  
文件根地址/image/128x，例如：
http://file.domain.com/files/1iYQTU7fEUgaa~URSVwaCqQKFml_IAAAAAgAAAAbhmsFjiUUQwCPn2ngI1QcvsSp0AA/image/128x

原图是JPG格式，下载png格式的图像  
文件根地址/image/raw_png，例如：
http://file.domain.com/files/1iYQTU7fEUgaa~URSVwaCqQKFml_IAAAAAgAAAAbhmsFjiUUQwCPn2ngI1QcvsSp0AA/image/raw_png

原图是JPG格式，下载png格式的128x128大小的缩略像  
文件根地址/image/128x128_png，例如：
http://file.domain.com/files/1iYQTU7fEUgaa~URSVwaCqQKFml_IAAAAAgAAAAbhmsFjiUUQwCPn2ngI1QcvsSp0AA/image/128x128_png

## 联系方式
Email: frank@mondol.info
