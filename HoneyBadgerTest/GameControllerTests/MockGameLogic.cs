using HoneyBadgers._0.BusinessLogic;
using HoneyBadgers._0.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoneyBadgerTest
{
	class MockGameLogic : IGameLogic
	{
		private readonly List<Game> _GameList;

		public List<Game> GetTestProducts()
		{
			var testProducts = new List<Game>();
			testProducts.Add(new Game
			{
				GameId = 1,
				GameName = " The Legend of Spyro",
				Publisher = "Activision",
				Developer = "Etranges Libellules",
				Genre = "Platformer",
				Platform = "All",
				GameDescription = "The Legend of Spyro trilogy is " +
										"set in a world populated by various creatures, with dragons being the most notable. Spyro " +
										"is a young dragon who hails from a line of rare purple dragons who are born once every ten generations" +
										" and prophesied to direct the fate of an era. While still an egg, he came under threat of The Dark Master " +
										"Malefor, who sought to prevent the prophecies from coming true. Spyro's egg was saved by the Fire Guardian," +
										" Ignitus, who left it to drift down a river, hoping for the best. Adopted and raised by dragonflies, " +
										"Spyro would soon discover who he is and his destiny to save his world and stop Malefor. Along the way, his adoptive dragonfly brother Sparx," +
										" follows Spyro loyally, helping Spyro find his way if he gets lost.[1] Spyro would also encounter Cynder, " +
										" an female dragon who was cursed by Malefor and was made to serve him. Cynder starts out as an" +
										" antagonist, but later joins Spyro's side in the battle against Malefor's forces. ",
				SystemReq = "I52500K or Better, 2gb ram, 2gb video graphics",
				GameArtUrl = "https://www.giantbomb.com/images/1300-2136555",
				ReleaseDate = new DateTime(2008, 10, 21),
				Price = 40.99
			});

			testProducts.Add(new Game
			{
				GameId = 2,
				GameName = " Crash Bandicoot",
				Publisher = "Sony Computer Entertainment",
				Developer = "Naughty Dog",
				Genre = "Platformer",
				Platform = "All",
				GameDescription = "n a southeast Australian archipelago, Doctor Neo Cortex and his assistant Doctor Nitrus Brio " +
									"use a device called the Evolvo-Ray to mutate the various animals living on the islands into beasts with superhuman strength. " +
									"They experiment on Crash, a peaceful bandicoot who Cortex intends to be the leader of his growing military of animal soldiers." +
									" Despite Brio's warnings, Cortex subjects Crash to the untested Cortex Vortex in an attempt to control him. The Vortex rejects Crash," +
									" allowing him to escape. After Crash leaps out a window and falls to the ocean below, Cortex prepares a female bandicoot named Tawna for experimentation." +
									"Having grown attached to Tawna during their time in captivity, Crash resolves to rescue her and defeat Cortex. " +
									 "From the beach of N. Sanity Island, Crash traverses through the islands and faces off against such adversaries as the local tribe leader Papu Papu," +
									  "[16] the deranged kangaroo Ripper Roo, the muscular Koala Kong, and the gangster Pinstripe Potoroo.[19] Within Cortex's castle, " +
									"Crash is confronted by Brio inside his laboratory. Brio uses chemicals to mutate himself into a monster. While Crash successfully defeats Brio," +
								 " the castle laboratory catches on fire during the struggle. Crash escapes to Cortex's airship, where he confronts Cortex himself as the castle burns. " +
								"Cortex attacks him with a plasma gun, but Crash deflects his own projectiles against him and sends Cortex falling out of the sky. " +
								 "Tawna embraces Crash as the two escape the burning castle on Cortex's airship.",
				GameArtUrl = "https://www.giantbomb.com/images/1300-1336263",
				ReleaseDate = new DateTime(1996, 09, 9),
				Price = 49.99
			});

			testProducts.Add(new Game
			{
				GameId = 3,
				GameName = "Diablo II",
				Publisher = "Blizzard Entertainment",
				Developer = "Blizzard North",
				Genre = "Action Role-Playing",
				Platform = "PC",
				GameDescription = "The story of Diablo II takes place soon after the end of the original Diablo." +
								  " At the end of Diablo, Diablo, Lord of Terror was defeated by a mortal hero. The hero who slew Diablo (i.e. the player character of the first game) " +
								 "drives the soulstone of Diablo (a magical stone containing the soul of a demon or angel) " +
								"into his own head in an attempt to contain Diablo in his own body. After this event, " +
								"the hero is rapidly corrupted by Diablo and slowly loses control of Diablo's soul. In the opening cinematic of Diablo II," +
								" Marius, the narrator of the story, witnesses the fallen hero (known only as the Dark Wanderer) totally lose control," +
								" unleashing the demons of Hell upon a tavern. Marius is the only survivor (it is implied that rather than just being blind luck, " +
								"the demons were ignoring him), and he feels compelled to follow the Wanderer for reasons he himself does not understand. The new player" +
								" character is a different hero following in the wake of the destruction, chasing the Dark Wanderer, hoping to put an end to the demon lord within him." +
								" The new hero ultimately catches up to the Wanderer outside the city of Kurast but is unable to stop him." +
								"The rest of the story is revealed through the four acts," +
								" as the player faces not just the demon lord Diablo, but two new major villains, his equally malevolent brothers, " +
								"fellow Prime Evils Mephisto, Lord of Hatred and Baal, " +
								"Lord of Destruction. Diablo is determined to free them from their soulstone incarceration, which was forced upon all three long ago," +
								" and from which Diablo managed to break free in the first game. The hero travels through different lands " +
								"to thwart the forces of The Burning Hells from conquering the world known as Sanctuary",
				GameArtUrl = "https://www.giantbomb.com/images/1300-2061347",
				ReleaseDate = new DateTime(2000, 06, 29),
				Price = 28.99
			});
			return testProducts;
		}

		public MockGameLogic()
		{
			_GameList = GetTestProducts();
		}

		public int Add(Game game)
		{
			_GameList.Add(game); 
			return 1;
		}

		public int Delete(int id)
		{
			Game gameToDelete = _GameList.Find(x => x.GameId == id);
			if(gameToDelete != null)
			{
				_GameList.Remove(gameToDelete);
				return 1;
			}
				return 0;
		}

		public Game Details(int id)
		{
			return _GameList.Find(x => x.GameId == id);
		}

		public IEnumerable<Game> GetAll()
		{
			return _GameList;
		}

		public int Update(Game game)
		{
			int index = _GameList.FindIndex(x => x.GameId == game.GameId);
			if (index > 0)
			{
				_GameList[index] = game;
				return 1;
			}
				return 0;
		}
	}
}
