using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Systeme_GS.BL
{
    public class D_Commande
    {

        //sauvgarder les produits qui commandée dans un liste
        public static List<D_Commande> listeDetail = new List<D_Commande>();
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Quantite { get; set; }
        public string Prix { get; set; }
        public string Remise { get; set; }
        public string Total { get; set; }

    }
}
