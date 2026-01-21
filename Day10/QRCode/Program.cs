// See https://aka.ms/new-console-template for more information
using System;
using System.IO;
using QRCoder;

string data = "https://www.google.com";

QRCodeGenerator qrGenerator = new QRCodeGenerator();
QRCodeData qrCodeData = qrGenerator.CreateQrCode(data, QRCodeGenerator.ECCLevel.Q);

PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
byte[] qrCodeBytes = qrCode.GetGraphic(20);

// Save QR code as image
File.WriteAllBytes("qrcode.png", qrCodeBytes);

Console.WriteLine("QR Code generated successfully!");

