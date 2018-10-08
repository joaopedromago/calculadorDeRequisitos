using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRLOCSistema.Bll
{
	public static class Util
	{
		public static bool ValidarNumero(KeyPressEventArgs e)
		{
			return !"0123456789".Contains(e.KeyChar.ToString()) && !Char.IsControl(e.KeyChar);
		}

		public static void CriarArquivoTexto(string arquivo, string conteudo)
		{
			string path = @"Db\" + arquivo + ".txt";
			using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
			{
				using (TextWriter tw = new StreamWriter(fs))
				{
					tw.Write(conteudo);
				}
			}
		}

		public static void BaixarArquivoTexto(string arquivo)
		{
			string path = @"Db\" + arquivo + ".txt";

			//File.Open(path, FileMode.Open);


		}
	}
}
