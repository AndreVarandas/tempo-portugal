using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IPMA.Core.Models
{
    public enum Districts
    {
        Aveiro = 1010500,
        Beja = 1020500,
        Braga = 1030300,
        [Display(Name = "Bragança")] Braganca = 1040200,
        [Display(Name = "Castelo Branco")] CasteloBranco = 1050200,
        Coimbra = 1060300,
        [Display(Name = "Évora")] Evora = 1070500,
        Faro = 1080500,
        Guarda = 1090700,
        Leiria = 1100900,
        Lisboa = 1110600,
        Portalegre = 1121400,
        Porto = 1131200,
        [Display(Name = "Santarém")] Santarem = 1141600,
        [Display(Name = "Setúbal")] Setubal = 1151200,
        [Display(Name = "Viana Do Castelo")] VianaDoCastelo = 1160900,
        [Display(Name = "Vila Real")] VilaReal = 1171400,
        Viseu = 1182300,
        Funchal = 2310300,
        [Display(Name = "Porto Santo")] PortoSanto = 2320100,
        [Display(Name = "Ponta Delgada")] PontaDelgada = 3420300,
        [Display(Name = "Angra do Heroísmo")] AngraDoHeroismo = 3430100,
        Horta = 3470100,

        [Display(Name = "Santa Cruz das Flores")]
        SantaCruzDasFlores = 3480200
    }
}