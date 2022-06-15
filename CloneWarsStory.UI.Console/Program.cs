using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;
using CloneWarsStory.Core.Models;
using CloneWarsStory.Core.Models.Delegates;
using CloneWarsStory.UI.Console;
using System.Globalization;
using System.Text;
using System.Linq;
using CloneWarsStory.UI.Console.Data;

//Piece2 piece2 = new Piece2(10);
//Piece2 piece3 = new Piece2(10);

//bool estEgal = piece2 == piece3;

DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
builder.UseMySQL("Server=127.0.0.1;Database=evanboissonnot;Uid=starwars;Pwd=Starwars_07062022!;");

using var context = new DefaultDbContext(builder.Options);

var query = from player in context.Players
            where player.Name == "Arthur"
            select player;

var playerR = query.First();

// playerR.Name = "Arthur";
// context.Players.Add(new Player());
context.Players.Remove(playerR);

context.SaveChanges();


TraitementPreAffichage();

Menu menu = new(
                    new MenuItem("Nouvelle Partie"),
                    new MenuItem("Charger"),
                    new MenuItem("A propos"),
                    new MenuItem("Quitter")
                    );


Console.WriteLine("Clone wars, a SW story !");

CultureInfo.CurrentCulture = new CultureInfo("en-US");
Console.WriteLine(CultureInfo.CurrentCulture.Name);

var isExit = false;
while (!isExit)
{
    AfficherMenu(menu);

    int choixF = 0;

    #region V1 du parsing int 
    //try
    //{
    //    string choix = Console.ReadLine();

    //    //if (string.IsNullOrEmpty(choix))
    //    //{

    //    //}
    //    choixF = int.Parse(choix);
    //}
    //catch (FormatException ex)
    //{
    //    Console.WriteLine(ex.Message);
    //}
    //catch (Exception ex)
    //{
    //    // System.FormatException exFormat = (System.FormatException) ex;
    //    //System.FormatException exFormat = ex as System.FormatException;

    //    //if (exFormat != null)
    //    //{
    //    //    Console.WriteLine(exFormat.Message);
    //    //}


    //    Console.WriteLine($"T'as fumé ? {ex.Message}");
    //}
    #endregion

    #region V2 du parsing int
    RecupererChoixMenuUtilisateur(ref choixF);
    #endregion

    ActionSelonChoixMenu(choixF);

    isExit = choixF == (int)ChoixMenu.Quitter;

    //ChoixMenu choixMenu = ChoixMenu.Quitter;
    //ChoixMenu choixMenu2 = (ChoixMenu) 1;
    // Console.WriteLine("isExit {0}", isExit);
}

static void RecupererChoixMenuUtilisateur(ref int choixF)
{
    bool choixOK = false;
    while (!choixOK)
    {
        Console.WriteLine("Votre choix ?");
        var choix = Console.ReadLine();
        choixOK = int.TryParse(choix, out choixF);
    }
}

static void LancerJeu()
{
    var prochainPas = new MaPropreRandomizeProchainPas(); // new RandomizeProchainPas();

    List<Personnage> personnages = new()
    {
        new Droide("1215485478", prochainPas),
        new Droide("BB45800", prochainPas),
        new Insectoide("bzzz", prochainPas)
    };
    // TraitementPreAffichage(personnages);


    Personnage persoPrincipal = new StormTrooper("Quatre", prochainPas);

    Console.Clear();
    while (true)
    {
        //Console.SetCursorPosition(0, 0);
        Console.Clear();

        personnages.ForEach(person =>
        {
            person.SeDeplacer();

            // Oops y a une rencontre 
            Combattre(person, persoPrincipal);

            person.Afficher(Console.WriteLine);
        });
    }
}

static void TraitementPreAffichage(List<Personnage> personnages = null)
{
    if (personnages == null)
    {
        var prochainPas = new MaPropreRandomizeProchainPas(); // new RandomizeProchainPas();

        personnages = new()
        {
            new Droide("1215485478", prochainPas),
            new Droide("BB45800", prochainPas),
            new Insectoide("bzzz", prochainPas)
        };
    }

    var query = from item in personnages
                where item.PointsDeVie > 0
                orderby item.PointsDeVie descending
                select new { PrenomMaj = item.Name.ToUpper() };

    var queryBis = query.Select(item => new { Test = item.PrenomMaj });

    var monPremierElement = query.FirstOrDefault();
    var monElement = query.SingleOrDefault();

    foreach (var item in query.Where(item => item.PrenomMaj != "TOTO").ToList())
    {
        Console.WriteLine($"====> {item.PrenomMaj}");
    }
}

static void Combattre(ICombattant combattant1, ICombattant combattant2)
{
    
}

static void ActionSelonChoixMenu(int choixF)
{
    Player player;

    switch ((ChoixMenu)choixF)
    {
        case ChoixMenu.Nouvelle_Partie:
            {
                Console.WriteLine("1");
                // Demander le pseudo du ST
                Console.WriteLine("Votre pseudo ?");
                var pseudo = Console.ReadLine();


                // Demander surtout la date de naissance valide du joueur !!
                Console.WriteLine("Votre date de naissance ?");
                var dateDeNaissanceS = Console.ReadLine();

                DateTime dateTime;
                if (DateTime.TryParse(dateDeNaissanceS, out dateTime))
                {
                    TimeSpan compareDates = DateTime.Now - dateTime;
                    if (compareDates.TotalDays / 365 < 13)
                    {
                        Console.WriteLine("Attention tu n'as pas l'âge requis ... ;)");

                        var dateFormatee = dateTime.ToString("dddd dd MMMM yy", new CultureInfo("fr-FR"));

                        Console.WriteLine($"Tu es né le {dateFormatee}");
                    }
                }
                else
                {
                    Console.WriteLine("Mauvais format de date !");
                }

                // Si < 13 ans, on demande à resaisir la date
                // Attention au format de la date saisie ;)
                // DD/MM/YYYY


                // player = new Player(pseudo, new DateOnly(dateTime.Year, dateTime.Month, dateTime.Day));
                // player = new Player(pseudo, DateOnly.FromDateTime(dateTime));
                Player player2 = new(pseudo, DateOnly.FromDateTime(dateTime));
                LancerJeu();
            }
            break;
        case ChoixMenu.Charger_Partie:
            {
                Console.WriteLine("2");
            }
            break;
        case ChoixMenu.A_Propos:
            {
                Console.WriteLine("3");
            }
            break;

        case < ChoixMenu.Quitter:
            {
                Console.WriteLine("Bye bye");

            }
            break;

        default:
            {
                Console.WriteLine("default");
            }
            break;
    }
}

static void DisplayOneItem(object item)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.BackgroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine(item);
}

/// <summary>
/// Affiche une fois le menu
/// </summary>
static void AfficherMenu(Menu menu)
{
    Menu menu2 = new(
                    new("Nouvelle Partie"),
                    new("Charger"),
                    new("A propos"),
                    new("Quitter")
                    );

    var query = from item in menu
                where ! item.Libelle.Contains('z')
                select item;

    List<DisplayAction> actions = new ()
    {
        Console.WriteLine,
        DisplayOneItem
    };
    Console.WriteLine("Quelle méthode d'affichage choisissez vous ? (1, 2 ?)");

    //menu.Display(DisplayOneItem);
    menu.Display(Console.WriteLine);

    Console.ForegroundColor = ConsoleColor.White;
    Console.BackgroundColor = ConsoleColor.Black;

    // menu.Display(item => Console.WriteLine(item));
    //var displayItem = (object item) => Console.WriteLine(item);
    // menu.Display(displayItem);


    //foreach (var choix in Enum.GetValues(typeof(ChoixMenu)))
    //{
    //    Console.WriteLine("{0} - {1}".ToUpper(), (int)choix, ((ChoixMenu)choix).ToString().Replace("_", " "));
    //}

    //int id = 1;

    //Console.WriteLine($"{id++} {".Nouvelle partie".ToUpper()}");

    //Console.WriteLine(String.Format("{0} {1} {1}", id++, ". Charger".ToUpper()));

    //Console.WriteLine("{0} {1}", id++, ". A propos".ToUpper());

    //Console.WriteLine((id++).ToString("00.##") + ". Quitter".ToUpper());

    //var valeurSaisie = Console.ReadLine();
    //Console.WriteLine(valeurSaisie);
}

