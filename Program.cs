using System.ComponentModel;

namespace net_ef_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {


            var choice = "";

            Console.WriteLine("Benvenuto!");
            Console.WriteLine("scegli cosa vuoi fare:");

            Console.WriteLine("- 1 - aggiungi videogioco\n- 2 - ricerca tramite Id\n- 3 - ricerca tramite Nome\n- 4 - elimina tramite id\n- 5 - Aggiungi softwarehouse ");


            while(choice != "exit")
            {
                Console.WriteLine("\nscegli cosa vuoi fare\n");
                choice = Console.ReadLine();

                switch (choice)
                {   //***************** Aggiungi videogioco
                    case "1":
                        Videogame gioco1 = new Videogame();
                        Console.Write("inserisci Videogioco:\nInserisci il nome:\n");
                        gioco1.VideogameName = Console.ReadLine();
                        Console.WriteLine("descrizione (opzionale)");
                        gioco1.VideogameDescription = Console.ReadLine();
                       
                        
                        Console.WriteLine("e ora il produttore");
                        gioco1.SoftwareHouseId = int.Parse(Console.ReadLine());

                        if (VideogameManager.InserisciVideogame(gioco1))
                        {
                            Console.WriteLine("il gioco è stato aggiunto con successo");
                        }else
                        {
                            Console.WriteLine("nuh huh si è verificato un errore");
                        }
                        break;

                       //******************** Ricerca per ID
                    case "2":
                        Console.Write("cerca per ID:\nInserisci il valore:\n");

                        int temp_int = int.Parse(Console.ReadLine());
                        Videogame? videogameById = VideogameManager.GetVideogameFromId(temp_int);
                        if (videogameById != null)
                        {
                            Console.WriteLine("il gioco è stato trovato con successo");
                            Console.WriteLine($"Nome\n{videogameById.VideogameName}\nDescrizione:\n{videogameById.VideogameDescription}\nProdotto da:\n {videogameById.SoftwareHouse}");
                        }
                        else
                        {
                            Console.WriteLine("nuh huh si è verificato un errore");
                        }
                        break;
                    //***************** Ricerca per Nome
                    case "3":
                        Console.Write("cerca per Nome:\nInserisci la stringa da ricercare:\n");
                        string temp_string = Console.ReadLine();
                        List<Videogame>? listOfGames = VideogameManager.GetVideogameFromName(temp_string);
                        if (listOfGames.Count != 0)
                        {
                            Console.WriteLine("i giochi sono stati trovati con successo");
                            foreach( Videogame game in listOfGames)
                            {
                                Console.WriteLine($"*****\nNome\n{game.VideogameName}\nDescrizione:\n{game.VideogameDescription}\nProdotto da:\n {game.SoftwareHouse}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("nuh huh si è verificato un errore");
                            continue;
                        }
                        break;
                    //***************** Rimuovi Videogioco
                    case "4":
                        Console.Write("rimuovi elemento:\nInserisci l'Id da rimuovere:\n");
                        int idToRemove = int.Parse(Console.ReadLine());
                        bool ans = VideogameManager.DeleteGameFromId(idToRemove);
                        if (ans)
                            Console.WriteLine("successo, l'elemento è stato eliminato");
                        else
                            Console.WriteLine("nuh huh si è verificato un errore");

                        break;
                    //****************** Aggiungi SoftwareHouse
                    case "5":
                        SoftwareHouse softHouseVar = new SoftwareHouse();
                        Console.Write("inserisci softwarehouse:\nInserisci il nome:\n");
                        softHouseVar.SoftwareHouseName = Console.ReadLine();
                        Console.WriteLine("descrizione (opzionale)");
                        softHouseVar.SoftwareHouseDescription = Console.ReadLine();



                        if (VideogameManager.AddSoftHouse(softHouseVar))
                        {
                            Console.WriteLine("la casa è stato aggiunta con successo");
                        }
                        else
                        {
                            Console.WriteLine("nuh huh si è verificato un errore");
                        }
                        break;

                    case "exit":break;
                }

            }

        }
    }
}
