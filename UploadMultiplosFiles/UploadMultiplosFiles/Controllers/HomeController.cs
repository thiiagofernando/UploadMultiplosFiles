using System;
using System.IO;
using System.Web.Mvc;
using UploadMultiplosFiles.Models;

namespace UploadMultiplosFiles.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Files arq)
        {
            try
            {
                string nomeArquivo = "";
                string ArquivoEnviado = "";
                Random rnd = new Random(DateTime.Now.Millisecond);
                foreach (var arquivo in arq.Arquivo)
                {
                    if (arquivo.ContentLength > 0)
                    {
                        nomeArquivo = Path.GetFileName(arquivo.FileName);
                        //string[] caminho = Directory.GetFiles((@"C:\arquivos\"), nomeArquivo);
                        //var caminho = Path.Combine(Server.MapPath("~/Imagens"), rnd.Next().ToString() + "-"+nomeArquivo);
                        var caminho = Path.Combine(Server.MapPath("~/Imagens"),nomeArquivo);
                        arquivo.SaveAs(caminho.ToString());
                    }
                    ArquivoEnviado = ArquivoEnviado + " , " + nomeArquivo;
                }
                ViewBag.Mensagem = "Arquivo: " + ArquivoEnviado + ", enviado com Sucesso";
            }
            catch (Exception ex)
            {
                ViewBag.Mensagem = "Erro: " + ex.Message;
            }
            return View();
        }
    }
}