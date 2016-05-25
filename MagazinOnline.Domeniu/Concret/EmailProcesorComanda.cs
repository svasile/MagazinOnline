using MagazinOnline.Domeniu.Abstract;
using System.Net.Mail;
using System.Text;
using MagazinOnline.Domeniu.Entitati;
using System.Net;

namespace MagazinOnline.Domeniu.Concret
{
    public class EmailProcesorComanda : IProcesareComanda
    {
        private SetariEmail setariEmail;

        public EmailProcesorComanda(SetariEmail setari )
        {
            setariEmail = setari;
        }
        public void ProcesareComanda(Cos cos, DetaliiCumparaturi detaliiCumparaturi)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = setariEmail.UtilizeazaSsl;
                smtpClient.Host = setariEmail.NumeServer;
                smtpClient.Port = setariEmail.PortServer;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = 
                    new NetworkCredential(setariEmail.Utilizator, setariEmail.Parola);

                StringBuilder corp = new StringBuilder()
                    .AppendLine("S-au comandat următoarele")
                    .AppendLine("---")
                    .AppendLine("Articole:");
                foreach(var rand in cos.rand)
                {
                    var total = rand.Produs.Pret * rand.Cantitate;
                    corp.AppendFormat("{0} x {1} (total: {2:c})\n",
                        rand.Cantitate,
                        rand.Produs.Denumire,
                        total);
                }
                corp.AppendFormat("Total comandă: {0:c}\n",
                    cos.CalculareValoareTotala())
                    .AppendLine("---")
                    .AppendLine("Cumpărător:")
                    .AppendLine(detaliiCumparaturi.Numele)
                    .AppendLine(detaliiCumparaturi.Adresa1)
                    .AppendLine(detaliiCumparaturi.Adresa2 ?? "")
                    .AppendLine(detaliiCumparaturi.Adresa3 ?? "")
                    .AppendLine(detaliiCumparaturi.Orasul)
                    .AppendLine(detaliiCumparaturi.Judetul)
                    .AppendLine(detaliiCumparaturi.Tara)
                    .AppendLine("---")
                    .AppendFormat("Cadou: {0}",detaliiCumparaturi.Cadou ? "Da" : "Nu");
                MailMessage mesajEmail = new MailMessage(
                    setariEmail.EmailDinAdresa,
                    setariEmail.EmailLaAdresa,
                    "O nouă comandă a fost lansată!",
                    corp.ToString());
                smtpClient.Send(mesajEmail);
            }
        }
    }
}
