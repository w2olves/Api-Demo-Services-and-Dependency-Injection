using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiDemo.Models;

namespace ApiDemo
{
    public class AuthorsDatastore
    {
        public static AuthorsDatastore Current { get; } = new AuthorsDatastore();
        public List<AuthorDto> Authors { get; set; }

        public AuthorsDatastore()
        {
            // init dummy data
            Authors = new List<AuthorDto>()
            {
                new AuthorDto()
                {
                    Id = 1,
                    Name = "Banana Yoshimoto",
                    Description =
                        "Yoshimoto was born in Tokyo on July 24, 1964 and grew up in a liberal family. Her father is the famous poet and critic Takaaki Yoshimoto, and her sister, Haruno Yoiko, is a well-known cartoonist in Japan.Yoshimoto graduated from Nihon University\'s Art College with a major in literature. While there, she adopted the pseudonym \"Banana\", after her love of banana flowers, a name she recognizes as both \"cute\" and \"purposefully androgynous.\"Yoshimoto keeps her personal life guarded and reveals little about her certified rolfing practitioner husband, Hiroyoshi Tahata, or son (born in 2003). Each day she takes half an hour to write at her computer, and she says, \"I tend to feel guilty because I write these stories almost for fun.\" Between 2008 and 2010, she maintained an online journal for English speaking fans.",
                    Books = new List<BooksDto>()
                    {
                        new BooksDto()
                        {
                            Id = 1,
                            Name = "Moonlight Shadow",
                            Description =
                                "The novella tells the story of a young woman, Satsuki, coming to terms with the death of her boyfriend, Hitoshi, in a car accident and her friendship with her boyfriend\'s brother, Hiiragi, whose girlfriend, Yumiko, also died in the same accident. With Japanese cultural and surrealistic themes, it is an example of Yoshimoto\'s clean writing style that portrays the emotions of grief, loss, and hope."
                        },
                        new BooksDto()
                        {
                            Id = 2,
                            Name = "Goodbye Tsugumi",
                            Description =
                                "Tsugumi is a sickly but feisty and somewhat unpleasant young girl living in a small Japanese seaside town at the family inn with her parents, sister Yoko, aunt Masako, and cousin Maria (the protagonist). Following the divorce of Maria\'s father, Maria and Masako move to Tokyo to be with him, where Maria attends university. Shortly after the move, Maria receives a call from Tsugumi to say that the family are selling the inn. Maria returns to the town for one last summer to remember her childhood and reconcile her strained relationship with Tsugumi while she still can. But then they didn\'t realize the true display of true will."
                        },
                    }
                },
                new AuthorDto()
                {
                    Id = 2,
                    Name = "Colonel Nit Tongsopit",
                    Description =
                        "The man the translator the biggest mystery to have come from Thailand. This is all that is known about him",
                    Books = new List<BooksDto>()
                    {
                        new BooksDto()
                        {
                            Id = 3,
                            Name = "English Conversation 99 : For Thai Students",
                            Description = "IMHO this book is now obsolete as afaik this does not cover mordern lingo"
                        },
                        new BooksDto()
                        {
                            Id = 4,
                            Name = "New Standard Thai-English Dictionary ",
                            Description = "Now known as the Old Standard"
                        },
                    }
                },
                new AuthorDto()
                {
                    Id = 3,
                    Name = "Ludwig von Baldass",
                    Description =
                        "was an Austrian art historian, professor and acclaimed author who specialised in Early Netherlandish painting. He studied under Max Dvořák at the University of Vienna and began to lecture there in 1926, gaining the position of professor in 1934. Von Baldass\' 1942 treatise on Hans Memling was instrumental in the re-evaluation of his artistic importance. Other publications include articles and books on Jan van Eyck (1952), Hieronymus Bosch (1953), Giorgione and Albrecht Altdorfer..",
                    Books = new List<BooksDto>()
                    {
                        new BooksDto()
                        {
                            Id = 5,
                            Name = "Albrecht Altdorfer",
                            Description =
                                "Albrecht Altdorfer also Albrecht Altdorffer (* around 1480 perhaps in Altdorf near Landshut or in Regensburg , 12 February 1538 in Regensburg ) was a German painter , copper cutter and master builder of the Renaissance . Along side Wolf Huber as the main champion of the so-called Danube School , a style of movement along the Danube in Bavaria and Austria. The artists of the art direction are also known as \"wild painters from the Danube\". Together with Albrecht Dürer , whose pupil he is, He is seen as the founder of the Nuremberg ministers . "
                        },
                        new BooksDto()
                        {
                            Id = 6,
                            Name = "Jan van Eyck",
                            Description =
                                "Jan van Eyck (* circa 1390 in Maaseik , † 1441 in Bruges ) was a Flemish painter of the Late Middle Ages and is regarded as the most famous representative of the old Netherlandish painting . He introduced the new naturalistic Kunstepoche north of the Alps . Because of his perfected technique and his sense of naturalism he was even described by many authors as \"king among the painters\"."
                        },
                    }
                },
                new AuthorDto()
                {
                    Id = 4,
                    Name = "Helen Knisely Bonk",
                    Description =
                        "Bonk, Helen Knisely was born on April 12, 1950 in Cleveland. Daughter of Angelo and Laura (Kelepouris) Pappis.",
                    Books = new List<BooksDto>()
                    {
                        new BooksDto()
                        {
                            Id = 7,
                            Name = "Foreign Trade Zones and Subzones: Their Uses and Effects for U. S. Manufacturers",
                            Description =
                                "No one has been able to write a description of this book, because its so boring, no one can read it more than 2 pages without falling asleep. You would think with a name like that, she would write a lively book...But no !"
                        },
                    }
                }
            };

        }
    }
}