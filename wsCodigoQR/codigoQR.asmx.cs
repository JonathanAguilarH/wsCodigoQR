using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace wsCodigoQR
{
    /// <summary>
    /// Descripción breve de codigoQR
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class codigoQR : System.Web.Services.WebService
    {

        [WebMethod]
        public Image aQR(string texto, int sizeQR)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.H);
            QrCode qrCode = new QrCode();
            qrEncoder.TryEncode(texto, out qrCode);
            GraphicsRenderer renderer = new GraphicsRenderer(new FixedCodeSize(sizeQR, QuietZoneModules.Zero), Brushes.Black, Brushes.White);
            MemoryStream ms = new MemoryStream();
            renderer.WriteToStream(qrCode.Matrix, ImageFormat.Png, ms);
            Image temporal = Image.FromStream(ms);
            Image QR = new Bitmap(temporal, new Size(new Point(sizeQR, sizeQR)));
            return QR;
        }
    }
}
