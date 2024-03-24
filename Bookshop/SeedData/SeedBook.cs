using System.IO;
namespace Bookshop.Data {
    public static class SeedBook {
        public static void EnsurePopulated(IApplicationBuilder app, IWebHostEnvironment hostEnvironment) {
            ShopDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<ShopDbContext>();
            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }
            if (!context.Books.Any()) {
                context.Books.AddRange(
                    new Book {
                        Title = "Harry Potter and the Sorcerer's Stone",
                        Author = "J. K. Rowling",
                        Coverpage = "/Coverpages/1.jpg".PathToByteArray(hostEnvironment),
                        PublishDate = new DateTime(1997, 6, 26),
                        Pages = 223,
                        Rating = 4.7m,
                        Price = 6.98m,
                        Categories = new List<Category>(),
                        //PDF = "/PDF/1.pdf".PDFPathToByteArray(hostEnvironment),
                        Description = "The book is about 11 year old Harry Potter, who receives a letter saying that he is invited to attend Hogwarts, school of witchcraft and wizardry. He then learns that a powerful wizard and his minions are after the sorcerer's stone that will make this evil wizard immortal and undefeatable.",

                    },
                    new Book {
                        Title = "Harry Potter and the Chamber of Secrets",
                        Author = "J. K. Rowling",
                        Coverpage = "/Coverpages/2.jpg".PathToByteArray(hostEnvironment),
                        PublishDate = new DateTime(1998, 7, 2),
                        Pages = 251,
                        Rating = 4.8m,
                        Price = 6.98m,
                        Categories = new List<Category>(),
                        //PDF = "/PDF/2.pdf".PDFPathToByteArray(hostEnvironment),
                        Description = "Ever since Harry Potter had come home for the summer, the Dursleys had been so mean and hideous that all Harry wanted was to get back to the Hogwarts School for Witchcraft and Wizardry. But just as he’s packing his bags, Harry receives a warning from a strange impish creature who says that if Harry returns to Hogwarts, disaster will strike.And strike it does. For in Harry’s second year at Hogwarts, fresh torments and horrors arise, including an outrageously stuck-up new professor and a spirit who haunts the girls’ bathroom. But then the real trouble begins – someone is turning Hogwarts students to stone. Could it be Draco Malfoy, a more poisonous rival than ever? Could it possibly be Hagrid, whose mysterious past is finally told? Or could it be the one everyone at Hogwarts most suspects… Harry Potter himself!",               
                    },
                    new Book {
                        Title = "Harry Potter and the Prisoner of Azkaban",
                        Author = "J. K. Rowling",
                        Coverpage = "/Coverpages/3.jpg".PathToByteArray(hostEnvironment),
                        PublishDate = new DateTime(1999, 7, 8),
                        Pages = 317,
                        Rating = 4.9m,
                        Price = 15.74m,
                        Categories = new List<Category>(),
                        //PDF = "/PDF/3.pdf".PDFPathToByteArray(hostEnvironment),
                        Description = "Harry Potter, along with his best friends, Ron and Hermione, is about to start his third year at Hogwarts School of Witchcraft and Wizardry. Harry can't wait to get back to school after the summer holidays. (Who wouldn't if they lived with the horrible Dursleys?) But when Harry gets to Hogwarts, the atmosphere is tense. There's an escaped mass murderer on the loose, and the sinister prison guards of Azkaban have been called in to guard the school...",
                    },
                    new Book {
                        Title = "Harry Potter and the Goblet of Fire",
                        Author = "J. K. Rowling",
                        Coverpage = "/Coverpages/4.jpg".PathToByteArray(hostEnvironment),
                        PublishDate = new DateTime(2000, 7, 8),
                        Pages = 636,
                        Rating = 4.9m,
                        Price = 6.92m,
                        Categories = new List<Category>(),
                        //PDF = "/PDF/4.pdf".PDFPathToByteArray(hostEnvironment),
                        Description = "It is the summer holidays and soon Harry Potter will be starting his fourth year at Hogwarts School of Witchcraft and Wizardry. Harry is counting the days: there are new spells to be learnt, more Quidditch to be played, and Hogwarts castle to continue exploring. But Harry needs to be careful - there are unexpected dangers lurking...",
                    },
                    new Book {
                        Title = "Harry Potter and the Order of the Phoenix",
                        Author = "J. K. Rowling",
                        Coverpage = "/Coverpages/5.jpg".PathToByteArray(hostEnvironment),
                        PublishDate = new DateTime(2003, 6, 21),
                        Pages = 766,
                        Rating = 4.8m,
                        Price = 17.29m,
                        Categories = new List<Category>(),
                        //PDF = "/PDF/5.pdf".PDFPathToByteArray(hostEnvironment),
                        Description = "Harry Potter is about to start his fifth year at Hogwarts School of Witchcraft and Wizardry. Unlike most schoolboys, Harry never enjoys his summer holidays, but this summer is even worse than usual. The Dursleys, of course, are making his life a misery, but even his best friends, Ron and Hermione, seem to be neglecting him.Harry has had enough. He is beginning to think he must do something, anything, to change his situation, when the summer holidays come to an end in a very dramatic fashion. What Harry is about to discover in his new year at Hogwarts will turn his world upside do",
                    },
                    new Book {
                        Title = "Harry Potter and the Half-Blood Prince",
                        Author = "J. K. Rowling",
                        Coverpage = "/Coverpages/6.jpg".PathToByteArray(hostEnvironment),
                        PublishDate = new DateTime(2005, 7, 16),
                        Pages = 607,
                        Rating = 4.9m,
                        Price = 16.79m,
                        Categories = new List<Category>(),
                        //PDF = "/PDF/6.pdf".PDFPathToByteArray(hostEnvironment),
                        Description = "It is the middle of the summer, but there is an unseasonal mist pressing against the windowpanes. Harry Potter is waiting nervously in his bedroom at the Dursleys' house in Privet Drive for a visit from Professor Dumbledore himself. One of the last times he saw the Headmaster was in a fierce one-to-one duel with Lord Voldemort, and Harry can't quite believe that Professor Dumbledore will actually appear at the Dursleys' of all places. Why is the Professor coming to visit him now? What is it that cannot wait until Harry returns to Hogwarts in a few weeks' time? Harry's sixth year at Hogwarts has already got off to an unusual start, as the worlds of Muggle and magic start to intertwi", 
                    },
                    new Book {
                        Title = "Harry Potter and the Deathly Hallows",
                        Author = "J. K. Rowling",
                        Coverpage = "/Coverpages/7.jpg".PathToByteArray(hostEnvironment),
                        PublishDate = new DateTime(2007, 7, 21),
                        Pages = 607,
                        Rating = 4.9m,
                        Price = 9.98m,
                        Categories = new List<Category>(),
                        //PDF = "/PDF/7.pdf".PDFPathToByteArray(hostEnvironment),
                        Description = "Harry has been burdened with a dark, dangerous and seemingly impossible task: that of locating and destroying Voldemort's remaining Horcruxes. Never has Harry felt so alone, or faced a future so full of shadows. But Harry must somehow find within himself the strength to complete the task he has been given. He must leave the warmth, safety and companionship of The Burrow and follow without fear or hesitation the inexorable path laid out for him...In this final, seventh installment of the Harry Potter series, J.K. Rowling unveils in",
                    }
                );
                context.SaveChanges();
            }
        }
        
        public static byte[] ImageToByteArray(this Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.SaveAsJpeg(ms);
                return ms.ToArray();
            }
        }
        public static byte[] PathToByteArray(this string path, IWebHostEnvironment hostEnvironment)
        {
            Image image = Image.Load(hostEnvironment.WebRootPath + path);
            byte[] imageByte = ImageToByteArray(image);
            return imageByte;
        }
        public static byte[] PdfToByteArray(this IFormFile pdf) {
            using (var ms = new MemoryStream()) {
                pdf.CopyTo(ms);
                return ms.ToArray();
            }
        }
        public static byte[] PDFPathToByteArray(this string path, IWebHostEnvironment hostEnvironment) {
            using (var ms = System.IO.File.OpenRead(hostEnvironment.WebRootPath + path)) {
                IFormFile pdf = new FormFile(ms, 0, ms.Length, null, Path.GetFileName(ms.Name));
                byte[] pdfByte = pdf.PdfToByteArray();
                return pdfByte;
            }
        }
        public static Image byteArrayToImage(this byte[] bytesArr)
        {
            using (MemoryStream memstr = new MemoryStream(bytesArr))
            {
                Image img = Image.Load(memstr);
                return img;
            }
        }
    }
}