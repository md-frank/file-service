using System;
using Mondol.FileService.Authorization.Codecs;
using Mondol.FileService.Authorization.Codecs.Impls;
using Xunit;

namespace FileServiceTests
{
    public class UrlDataCodecTest
    {
        [Fact]
        public void Encode()
        {
            byte[] bys = { 0x68, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x77, 0x6F, 0x72, 0x64 };
            var udc = new UrlDataCodecV2();
            Assert.Equal("2aGVsbG8gd29yZA", udc.Encode(bys));

            bys = new byte[] { 0x68, 0x65, 0x6C, 0x6C, 0x6F, 0x77, 0x6F, 0x72, 0x64 };
            Assert.Equal("2aGVsbG93b3Jk", udc.Encode(bys));
        }

        [Fact]
        public void Decode()
        {
            byte[] bys = { 0x68, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x77, 0x6F, 0x72, 0x64 };
            var udc = new UrlDataCodecV2();
            var bys2 = udc.Decode("2aGVsbG8gd29yZA");
            Assert.Equal(bys, bys2);

            bys = new byte[] { 0x68, 0x65, 0x6C, 0x6C, 0x6F, 0x77, 0x6F, 0x72, 0x64 };
            bys2 = udc.Decode("2aGVsbG93b3Jk");
            Assert.Equal(bys, bys2);
        }

        [Fact]
        public void CompatibilityCodec()
        {
            var udcV1 = new UrlDataCodecV1();
            var udcV2 = new UrlDataCodecV2();
            var udc = new UrlDataCompatibilityCodec();

            byte[] bys = { 0x68, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x77, 0x6F, 0x72, 0x64 };
            var str = udcV1.Encode(bys);
            var bys2 = udc.Decode(str);
            Assert.Equal(bys, bys2);

            str = udcV2.Encode(bys);
            bys2 = udc.Decode(str);
            Assert.Equal(bys, bys2);
        }
    }
}
