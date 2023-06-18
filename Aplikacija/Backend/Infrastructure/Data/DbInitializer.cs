using Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data
{
    // static, moze da se koristi klasa bez poziva instance
    public static class DbInitializer
    {
        public static async Task Initialize(StoreContext context, UserManager<User> UserManager)
        {
            if (!UserManager.Users.Any()) 
            {
                var user = new User
                {
                    UserName = "boban",
                             Email = "boban@test.com"
                };

                await UserManager.CreateAsync(user, "Pa$$w0rd");
                await UserManager.AddToRoleAsync(user, "Member");

                var admin = new User
                {
                    UserName = "admin",
                             Email = "admin@test.com"
                };

                await UserManager.CreateAsync(admin, "Pa$$w0rd");
                await UserManager.AddToRolesAsync(admin, new[] {"Member", "Admin"});
            }

            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product
                {
                    Name = "Brašno-danubius",
                         Description =
                             "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                         Price = 55,
                         PictureUrl = "/images/products/brasno-danubius.png",
                         Brand = "Namirnice",
                         Type = "Proizvedeno u Srbiji",
                         QuantityInStock = 100
                },
                    new Product
                    {
                        Name = "Griz Začin C",
                        Description = "Nunc viverra imperdiet enim. Fusce est. Vivamus a tellus.",
                        Price = 120,
                        PictureUrl = "/images/products/brasno-griz.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Brašno Kikindsko",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 133,
                        PictureUrl = "/images/products/brasno-kikindski.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Brašno Mlinar",
                        Description =
                            "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                        Price = 155,
                        PictureUrl = "/images/products/brasno-mlinar.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Brašno Senćansko",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 221,
                        PictureUrl = "/images/products/brasno-sentella.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Puding C Banana",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 35,
                        PictureUrl = "/images/products/puding-c-banana.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Puding C Jagoda",
                        Description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 43,
                        PictureUrl = "/images/products/puding-c-jagoda.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Puding C Slatka Pavlaka",
                        Description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 80,
                        PictureUrl = "/images/products/puding-c-slatka.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Puding C Vanila",
                        Description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 28,
                        PictureUrl = "/images/products/puding-c-vanila.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "DrOetker puding narandza",
                        Description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 120,
                        PictureUrl = "/images/products/puding-dr-oetker1.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "DrOetker puding breskva",
                        Description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 135,
                        PictureUrl = "/images/products/puding-dr-oetker2.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "DrOetker Puding Original",
                        Description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 75,
                        PictureUrl = "/images/products/puding-dr-oetker3.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Šećer ZačinC",
                        Description =
                            "Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 88,
                        PictureUrl = "/images/products/secer-c.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Šećer Crvenka",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 77,
                        PictureUrl = "/images/products/secer-crvenka.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Šećer Sunoko",
                        Description =
                            "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar ultricies, purus lectus malesuada libero, sit amet commodo magna eros quis urna.",
                        Price = 67,
                        PictureUrl = "/images/products/secer-sunoko.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Šećer u prahu Sunoko",
                        Description =
                            "Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Proin pharetra nonummy pede. Mauris et orci.",
                        Price = 55,
                        PictureUrl = "/images/products/secer-u-prahu-sunoko.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Jabukovo Sirće",
                        Description = "Aenean nec lorem. In porttitor. Donec laoreet nonummy augue.",
                        Price = 225,
                        PictureUrl = "/images/products/jabukovo-sirce.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Alkoholno Sirće",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 187,
                        PictureUrl = "/images/products/alkoholno-sirce.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Limunov Sok",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 124,
                        PictureUrl = "/images/products/limunov-sok.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Vinsko Sirće",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 299,
                        PictureUrl = "/images/products/vinsko-sirce.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Šlag C Fantastiko",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 120,
                        PictureUrl = "/images/products/slag-c-fantastico.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Šlag Dr Oetker pena",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 221,
                        PictureUrl = "/images/products/slag-dr-oetker.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Šlag C krem",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 144,
                        PictureUrl = "/images/products/slag-krem-c-beli.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Šlag Meggle",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 399,
                        PictureUrl = "/images/products/slag-meggle.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Tuzlanska So",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 99,
                        PictureUrl = "/images/products/so-tuzlanska.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Morska So",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 139,
                        PictureUrl = "/images/products/morska-so.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },

                    new Product
                    {
                        Name = "Barilla Bavette",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 355,
                        PictureUrl = "/images/products/barilla-bavette.png",
                        Brand = "Namirnice",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Barilla Farfalle",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 399,
                        PictureUrl = "/images/products/barilla-farfalle.png",
                        Brand = "Namirnice",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Barilla Pene",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 379,
                        PictureUrl = "/images/products/barilla-pene.png",
                        Brand = "Namirnice",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Barilla Spaghetti",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 499,
                        PictureUrl = "/images/products/barilla-spaghetti.png",
                        Brand = "Namirnice",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Castello Elicoidali",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 699,
                        PictureUrl = "/images/products/castello-elicoidali.png",
                        Brand = "Namirnice",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },
                    new Product
                    {
                        Name = "Castello Penne",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 559,
                        PictureUrl = "/images/products/castello-penne.png",
                        Brand = "Namirnice",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },
                    new Product               
                    {
                        Name = "Castello Tagliatelle",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 899,
                        PictureUrl = "/images/products/castello-tagliatelle.png",
                        Brand = "Namirnice",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Danubius Gnocchi",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 299,
                        PictureUrl = "/images/products/danubius-gnocchi.png",
                        Brand = "Namirnice",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Danubius Penne",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 399,
                        PictureUrl = "/images/products/danubius-penne.png",
                        Brand = "Namirnice",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },

                    new Product              
                    {
                        Name = "Maslinovo Ulje Monini",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 155,
                        PictureUrl = "/images/products/maslinovo-ulje-monini.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Suncokretovo Ulje Dijamant",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 279,
                        PictureUrl = "/images/products/ulje-dijamant.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",

                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Palmino Ulje Dijamant",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 349,
                        PictureUrl = "/images/products/ulje-dijamant-m.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Suncokretovo Ulje Iskon",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 210,
                        PictureUrl = "/images/products/ulje-iskon.png",
                        Brand = "Namirnice",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    // MLECNI PROIZVODI
                    new Product              
                    {
                        Name = "Jogurt Balans",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 199,
                        PictureUrl = "/images/products/jogurt-balans1.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Jogurt Bello",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 249,
                        PictureUrl = "/images/products/jogurt-bello.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Jogurt Dukat",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 199,
                        PictureUrl = "/images/products/jogurt-dukat.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Dukatos",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 188,
                        PictureUrl = "/images/products/jogurt-grcki3.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Grekos Običan",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 175,
                        PictureUrl = "/images/products/jogurt-grcki4.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Grekos Jagoda",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 192,
                        PictureUrl = "/images/products/jogurt-grcki5.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Grekos Višnja",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 192,
                        PictureUrl = "/images/products/jogurt-grcki6.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Jogurt Moja Kravica",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 222,
                        PictureUrl = "/images/products/jogurt-kravica.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Kiselo Mleko Balans",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 169,
                        PictureUrl = "/images/products/kiselo-mleko-balans.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Kiselo Mleko Dukat",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 149,
                        PictureUrl = "/images/products/kiselo-mleko-dukat.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Kiselo Mleko Imlek",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 184,
                        PictureUrl = "/images/products/kiselo-mleko-imlek.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Kiselo Mleko Meggle",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 210,
                        PictureUrl = "/images/products/kiselo-mleko-meggle.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Kiselo Mleko Zdravo",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 155,
                        PictureUrl = "/images/products/kiselo-mleko-zdravo.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Proizvedeno u Srbiji",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Mleko Alpsko 3.5% jako",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 186,
                        PictureUrl = "/images/products/mleko-alpsko.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekare Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Mleko Bello 3.5%",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 155,
                        PictureUrl = "/images/products/mleko-bello.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekare Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Punomasno mleko Dukat",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 166,

                        PictureUrl = "/images/products/mleko-dukat.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekare Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Mleko Moja kravica 2.8%",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 155,
                        PictureUrl = "/images/products/mleko-imlek.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekare Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Mleko Moja Kravica 3.2%",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 189,
                        PictureUrl = "/images/products/mleko-imlek-32.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekare Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Mleko Imlek Bello",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 279,
                        PictureUrl = "/images/products/mleko-imlek-bello.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekare Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Mleko Implek 3.2%",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 177,
                        PictureUrl = "/images/products/mleko-imlek-punomasno.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekare Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Punomasno Mleko Imlek",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 155,
                        PictureUrl = "/images/products/mleko-imlek-s.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekare Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Mleko Moja Kravica Junior",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 199,
                        PictureUrl = "/images/products/mleko-junior.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekare Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Mleko Meggle 2.8%",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 189,
                        PictureUrl = "/images/products/mleko-meggle.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekare Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Punomasno Mleko Mlekara Subotica",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 155,
                        PictureUrl = "/images/products/mleko-subotica.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekare Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Mleko Meggle 3.2%",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 160,
                        PictureUrl = "/images/products/mleko-meggle-32.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekare Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Beli Sir Grekos 500g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 699,
                        PictureUrl = "/images/products/beli-sir-grekos-500g.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekare Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Beli Mladi Sir Perfetta",

                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 399,
                        PictureUrl = "/images/products/beli-sir-perfetta-500g.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekare Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Cheddar Sir Paladin",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1290,
                        PictureUrl = "/images/products/cheddar-paladin.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekare Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Edam Kačkavalj 500g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 900,
                        PictureUrl = "/images/products/edam-president.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekare Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Somborska Feta President",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 669,
                        PictureUrl = "/images/products/feta-president-500g.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Gauda Belje",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 750,
                        PictureUrl = "/images/products/gauda-belje.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Imlek Irski Sir Kolut",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 160,
                        PictureUrl = "/images/products/iriski-sir.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "CALABRIA Parmezan",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 122,
                        PictureUrl = "/images/products/parmezan-40g.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Trapist Biser",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 333,
                        PictureUrl = "/images/products/trapist-biser.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Dukat Voćni Jogurt Jagoda",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 199,
                        PictureUrl = "/images/products/vocni-jogurt-dukat-jagoda.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekara Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Dukat Voćni Jogurt Šumsko Voće",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 220,
                        PictureUrl = "/images/products/vocni-jogurt-dukat-sumsko.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekara Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Dukat Voćni Jogurt Višnja",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 239,
                        PictureUrl = "/images/products/vocni-jogurt-dukat-visnja.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekara Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Vonćni Jogurt Zdravo Jagoda",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 240,
                        PictureUrl = "/images/products/vocni-jogurt-jagoda.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekara Srbija",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Vonćni Jogurt Zdravo Šumsko Voće",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 220,
                        PictureUrl = "/images/products/vocni-jogurt-zdravo-sumsko.png",
                        Brand = "Mlecni Proizvodi",
                        Type = "Mlekara Srbija",
                        QuantityInStock = 100
                    },
                    // VOCE I POVRCE
                    new Product              
                    {
                        Name = "Čeri Paradajz",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 299,
                        PictureUrl = "/images/products/cherry.png",
                        Brand = "Povrće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Cvekla crvena",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 89,
                        PictureUrl = "/images/products/cvekla.png",
                        Brand = "Povrće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Karfiol",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 149,
                        PictureUrl = "/images/products/karfiol.png",
                        Brand = "Povrće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Krastavac",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 199,
                        PictureUrl = "/images/products/krastavac.png",
                        Brand = "Povrće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Mladi Kupus",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 49,
                        PictureUrl = "/images/products/kupus.png",
                        Brand = "Povrće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Beli Luk",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 269,
                        PictureUrl = "/images/products/luk.png",
                        Brand = "Povrće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Paprika Žuta",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 239,
                        PictureUrl = "/images/products/paprika1.png",
                        Brand = "Povrće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Paprika Crvena",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 219,
                        PictureUrl = "/images/products/paprika2.png",
                        Brand = "Povrće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },
                    new Product              
                    {
                        Name = "Paradajz",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 299,
                        PictureUrl = "/images/products/paradajz.png",
                        Brand = "Povrće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },                
                    new Product              
                    {
                        Name = "Pasulj Beli",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 349,
                        PictureUrl = "/images/products/pasulj-beli.png",
                        Brand = "Povrće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },                
                    new Product              
                    {
                        Name = "Plavi Patlidzan",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 299,
                        PictureUrl = "/images/products/patlidzan.png",
                        Brand = "Povrće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },                
                    new Product              
                    {
                        Name = "Zreli Praziluk",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 199,
                        PictureUrl = "/images/products/praziluk.png",
                        Brand = "Povrće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },                
                    new Product              
                    {
                        Name = "Šampinjoni",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 159,
                        PictureUrl = "/images/products/sampnjoni.png",
                        Brand = "Povrće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },                
                    new Product              
                    {
                        Name = "Šargarepa",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 119,
                        PictureUrl = "/images/products/sargarepa.png",
                        Brand = "Povrće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },                
                    new Product              
                    {
                        Name = "Zelena Salata",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 129,
                        PictureUrl = "/images/products/zelenas.png",
                        Brand = "Povrće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },                
                    new Product              
                    {
                        Name = "Ananas",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 299,
                        PictureUrl = "/images/products/ananas.png",
                        Brand = "Voće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Avokado",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 229,
                        PictureUrl = "/images/products/avokado.png",
                        Brand = "Voće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Banane",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 199,
                        PictureUrl = "/images/products/banane.png",
                        Brand = "Voće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },                                   
                    new Product              
                    {
                        Name = "Crveni Grejpfrut",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 169,
                        PictureUrl = "/images/products/grejp-crveni.png",
                        Brand = "Voće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Jabuka Ajdared",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 220,
                        PictureUrl = "/images/products/jabuke-ajdared.png",
                        Brand = "Voće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Jabuka Zeleni Delišes",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 119,
                        PictureUrl = "/images/products/jabuke-delises.png",
                        Brand = "Voće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Jabuka Greni Smit",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 179,
                        PictureUrl = "/images/products/jabuke-greni.png",
                        Brand = "Voće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Kivi",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 229,
                        PictureUrl = "/images/products/kivi.png",
                        Brand = "Voće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Kruška",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 199,
                        PictureUrl = "/images/products/kruske.png",
                        Brand = "Voće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Limeta",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 399,
                        PictureUrl = "/images/products/limeta.png",
                        Brand = "Voće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Limun",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 189,
                        PictureUrl = "/images/products/limun.png",
                        Brand = "Voće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Mango",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 199,
                        PictureUrl = "/images/products/mango.png",
                        Brand = "Voće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Nektarina",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 179,
                        PictureUrl = "/images/products/nektarina.png",
                        Brand = "Voće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Pomelo",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 249,
                        PictureUrl = "/images/products/pomelo.png",
                        Brand = "Voće",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    // MESO
                    new Product              
                    {
                        Name = "Budimška Carnex 450g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 699,
                        PictureUrl = "/images/products/budimska-carnex.png",
                        Brand = "Meso",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Budimška Salama Tanko Rezana 450g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 679,
                        PictureUrl = "/images/products/budimska-yuhor.png",
                        Brand = "Meso",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Ćevapi 300g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 249,
                        PictureUrl = "/images/products/cevapi.png",
                        Brand = "Meso",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Jagnjetina 1kg",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1099,
                        PictureUrl = "/images/products/jagnjetina.png",
                        Brand = "Meso",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Juneća Leđa Sa Kostima 500g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 899,
                        PictureUrl = "/images/products/juneca-leda-sa-kostima.png",
                        Brand = "Meso",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Juneća Rebra 300g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 499,
                        PictureUrl = "/images/products/juneca-rebra.png",
                        Brand = "Meso",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Kulen NEOPLANTA",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 369,
                        PictureUrl = "/images/products/kulen-neoplanta.png",
                        Brand = "Meso",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Kulen Topola Domaći 200g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 389,
                        PictureUrl = "/images/products/kulen-topola.png",
                        Brand = "Meso",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Pečenica Domaća",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 399,
                        PictureUrl = "/images/products/pecenica-carnex.png",
                        Brand = "Meso",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Pikant Čajna 200g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 189,
                        PictureUrl = "/images/products/piknik-topola.png",
                        Brand = "Meso",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Pljeskavice 100g Komad",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 249,
                        PictureUrl = "/images/products/pljeskavice.png",
                        Brand = "Meso",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Roštilj Kobasice 600g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 459,
                        PictureUrl = "/images/products/rostilj-kobasice.png",
                        Brand = "Meso",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Sendvič Salama",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 199,
                        PictureUrl = "/images/products/sendvic-salama-zlatiborac.png",
                        Brand = "Meso",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Svinjska Plećka Bez Kostiju 500g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 689,
                        PictureUrl = "/images/products/svinjska-plecka-bez-kostiju.png",
                        Brand = "Meso",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Svinjski File",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 599,
                        PictureUrl = "/images/products/svinjski-file.png",
                        Brand = "Meso",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Svinjski Vrat Sa Kostima 600g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 701,
                        PictureUrl = "/images/products/svinjski-vrat-sa-kostima.png",
                        Brand = "Meso",
                        Type = "NIIR nase domaće",
                        QuantityInStock = 100
                    }, 
                    // Slatkisi
                    new Product              
                    {
                        Name = "Biskvit Jaffa Choco Narandza",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 222,
                        PictureUrl = "/images/products/biskit-jaffa-choco.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Biskvit Nobilce 300g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 299,
                        PictureUrl = "/images/products/biskvit-banini-noblice.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Biskvit Milka Pomorandza",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 329,
                        PictureUrl = "/images/products/biskvit-milka-biskvit-pomorandza.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Išleri Swisslion Takovo",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 169,
                        PictureUrl = "/images/products/biskvit-swisslion-isleri.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Fisher-man Friend Bombone Original",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 98,
                        PictureUrl = "/images/products/bombone-fisherman-extra.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Fisher-man Friend Bombone Mint",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 110,
                        PictureUrl = "/images/products/bombone-fisherman-s.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Bombone 505 sa crtom",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 129,
                        PictureUrl = "/images/products/bombone-kras-505.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "M&M Kikiriki",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 189,
                        PictureUrl = "/images/products/bombone-m.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Bombone Mentos Fruit",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 55,
                        PictureUrl = "/images/products/bombone-mentos-fruit.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Bombone Mentos Grape",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 169,
                        PictureUrl = "/images/products/bombone-mentos-grape.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Bombone Mentos Mint",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 59,
                        PictureUrl = "/images/products/bombone-mentos-mint.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "M&M Čokolada",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 199,
                        PictureUrl = "/images/products/bombone-m-m-s-cokolada.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Bombone Pionir Menthol Strong",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 131,
                        PictureUrl = "/images/products/bombone-pionir-menthol-strong.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Bombone Pionir Negro",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 121,

                        PictureUrl = "/images/products/bombone-pionir-negro.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Čips Marbo Domaćinski Feta",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 210,
                        PictureUrl = "/images/products/cips-marbo-chipsy-domacinski-feta.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Čokolada Kinder 100g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 132,
                        PictureUrl = "/images/products/cokolada-kinder.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Čokolada Milka",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 249,
                        PictureUrl = "/images/products/cokolada-milka.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Čokolada Milka Bubbly 100g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 279,
                        PictureUrl = "/images/products/cokolada-milka-bubbly.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Galeb Pionir Čokolada 100g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 99,
                        PictureUrl = "/images/products/cokolada-pionir.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Čokolada-Schogetten Original",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 239,
                        PictureUrl = "/images/products/cokolada-schogetten.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Čokolada Schogetten Caramel 100g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 199,
                        PictureUrl = "/images/products/cokolada-schogetten-careml.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Čokolada Schogetten Hazelnuts 100g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 149,
                        PictureUrl = "/images/products/cokolada-schogetten-hazelnuts.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Čokolada Schogetten Noisettes 100g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 169,
                        PictureUrl = "/images/products/cokolada-schogetten-noisettes.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Štark Najlepše Želje 100g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 200,
                        PictureUrl = "/images/products/cokolada-stark.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Keks Bambi Plazma 100g",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 169,
                        PictureUrl = "/images/products/keks-bambi-plazma.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Marbo Chipsy Classic",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 79,
                        PictureUrl = "/images/products/marbo-chipsy-classic.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Marbo Chipsy Rebrasti Pizza",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 162,
                        PictureUrl = "/images/products/marbo-chipsy-rebrasti.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Marbo Chipsy Slani",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 163,
                        PictureUrl = "/images/products/marbo-chipsy-slani.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Marbo Chipsy Tzatziki",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 139,
                        PictureUrl = "/images/products/marbo-chipsy-tzatziki.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Orbit Original",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 55,
                        PictureUrl = "/images/products/zvake-orbit.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Orbit Eucaliptus",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 88,
                        PictureUrl = "/images/products/zvake-orbit-eucalyptu.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Orbit Green Mint",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 77,
                        PictureUrl = "/images/products/zvake-orbit-green-mint.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Orbit Winterfrost",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 79,
                        PictureUrl = "/images/products/zvake-orbit-winterfrost.png",
                        Brand = "Grickalice",
                        Type = "ChipsAndSnacks",
                        QuantityInStock = 100
                    }, 
                    //BEBE
                    new Product              
                    {
                        Name = "Dečija Krema Nivea",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 239,
                        PictureUrl = "/images/products/decija-krema-nivea.png",
                        Brand = "Bebe",
                        Type = "Nivea",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Dečija Krema Pavloderm",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 299,
                        PictureUrl = "/images/products/decija-krema-pavloderm.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Dečija Kupka Nivea",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 499,
                        PictureUrl = "/images/products/decija-kupka-nivea.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Dečija Krema Becutan",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 199,
                        PictureUrl = "/images/products/krema-becutan.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Dečija Kupka Kosili Plava",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 189,
                        PictureUrl = "/images/products/kupka-kosili-plava.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Dečija Kupka Kosili Roza",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 189,
                        PictureUrl = "/images/products/kupka-kosili-roza.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Dečija Hrana BabyKing Pet Žitarica",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 299,
                        PictureUrl = "/images/products/decija-hrana-flory1.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Dečija Hrana BabyKing Cacao And Milk",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 399,
                        PictureUrl = "/images/products/decija-hrana-flory2.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Dečija Hrana BabyKing Ananas Fruits",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 329,
                        PictureUrl = "/images/products/decija-hrana-flory3.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Dečija Hrana BabyKing 10 Vitamina",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 399,
                        PictureUrl = "/images/products/decija-hrana-flory4.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Dečija Hrana BabyKing Lion Power",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 289,
                        PictureUrl = "/images/products/decija-hrana-flory5.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Nutrino Kakao Kaša",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 399,
                        PictureUrl = "/images/products/nutrino-kakao-kasa.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Nutrino Kakao Kaša Sa Bananom",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 399,
                        PictureUrl = "/images/products/nutrino-kasa-banana.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Nutrino Kaša Šest Vitamina",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 399,
                        PictureUrl = "/images/products/nutrino-kasa-ovas.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    }, 
                    new Product              
                    {
                        Name = "Pelene Pampers Pants Monthly Pack 4",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 3999,
                        PictureUrl = "/images/products/pelene-pampers-pants-1.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    },                 
                    new Product              
                    {
                        Name = "Pelene Pampers Pants Monthly Pack 5",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 4999,
                        PictureUrl = "/images/products/pelene-pampers-pants-2.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    },                 
                    new Product              
                    {
                        Name = "Pelene Pampers Pants Monthly Pack 6",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 5999,
                        PictureUrl = "/images/products/pelene-pampers-pants-3.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    },                 
                    new Product              
                    {
                        Name = "Pelene Pampers Pants",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 2499,
                        PictureUrl = "/images/products/pelene-pampers-pelene1.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    },                 
                    new Product              
                    {
                        Name = "Pelene Pampers Pants 2 Week Pack",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1899,
                        PictureUrl = "/images/products/pelene-pampers-pelene2.png",
                        Brand = "Bebe",
                        Type = "Pampers",
                        QuantityInStock = 100
                    },                 
                    new Product              
                    {
                        Name = "Pelene Pampers Pants Box 15 Days",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 3799,
                        PictureUrl = "/images/products/pelene-pampers-pelene3.png",
                        Brand = "Bebe",
                        Type = "Pampers",
                        QuantityInStock = 100
                    },                 
                    new Product              
                    {
                        Name = "Pelene Pampers Pants Mega Box 30 Days",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 7999,
                        PictureUrl = "/images/products/pelene-pampers-pelene4.png",
                        Brand = "Bebe",
                        Type = "Pampers",
                        QuantityInStock = 100
                    },                 
                    new Product              
                    {
                        Name = "Pelene Pampers Originals Classic",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1399,
                        PictureUrl = "/images/products/pelene-pampers-pelene-56.png",
                        Brand = "Bebe",
                        Type = "Pampers",
                        QuantityInStock = 100
                    },                 
                    new Product              
                    {
                        Name = "Pelene Pampers Originals Box 90 Peaces",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 11999,
                        PictureUrl = "/images/products/pelene-pampers-pelene-90kom.png",
                        Brand = "Bebe",
                        Type = "Pampers",
                        QuantityInStock = 100
                    },                 
                    new Product              
                    {
                        Name = "Pelene Pampers Originals Box 144 Peaces",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 21999,
                        PictureUrl = "/images/products/pelene-pampers-pelenep-144.png",
                        Brand = "Bebe",
                        Type = "Pampers",
                        QuantityInStock = 100
                    },                 
                    new Product              
                    {
                        Name = "Pelene Pufies Thinker Box S",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 7999,
                        PictureUrl = "/images/products/pelene-pufies1.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    },                 
                    new Product              
                    {
                        Name = "Pelene Pufies Thinker Box M",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1799,
                        PictureUrl = "/images/products/pelene-pufies3.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    },                 
                    new Product              
                    {
                        Name = "Pelene Pufies Pants Big Box Set",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 9999,
                        PictureUrl = "/images/products/pelene-pufies4.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    },                 
                    new Product              
                    {
                        Name = "Pelene Pufies Pants Box Set",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 8999,
                        PictureUrl = "/images/products/pelene-pufies5.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    },                 
                    new Product              
                    {
                        Name = "Pelene Pufies Thinker Box L",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 10999,
                        PictureUrl = "/images/products/pelene-pufies6.png",
                        Brand = "Bebe",
                        Type = "Nutrino",
                        QuantityInStock = 100
                    },       
                    // Kucna Hemija
                    new Product              
                    {
                        Name = "Ariel Pods Kapsule",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 999,
                        PictureUrl = "/images/products/ariel-pods-kapsule.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Cif Odmašćivač PowerGel",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 420,
                        PictureUrl = "/images/products/cif-odmascivac.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Deterdzent Za Posuđe Fairy Mercuty Original",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 279,
                        PictureUrl = "/images/products/deterdzent-za-posude-fairy-mercury.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Deterdzent Za Posuđe Fairy Mercuty Lemon",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 349,
                        PictureUrl = "/images/products/deterdzent-za-posude-fairy-mercury-lemon.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Deterdzent Za Posuđe Fairy Mercuty Pomergranate",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 259,
                        PictureUrl = "/images/products/deterdzent-za-posude-fairy-mercury-pomegranate.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Frosch Sredstvo Za Čišćenje Citrus",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 366,
                        PictureUrl = "/images/products/frosch-sredstvo-za-ciscenje-citrus.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Lenor Pods Amethyst",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 3199,
                        PictureUrl = "/images/products/lenor-pods-amethyst.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Lenor Pods Spring Scents",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 3399,
                        PictureUrl = "/images/products/lenor-pods-spring-awakening.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Merix Kapsule Lotos I Badem",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 3899,
                        PictureUrl = "/images/products/merix-kapsule-lotos-i-bademovo.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Merix Kapsule Orhideja I Makadam",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 3899,
                        PictureUrl = "/images/products/merix-kapsule-orhideja-makadamija.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Persil Kapsule Discs Forumla",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 3999,
                        PictureUrl = "/images/products/persil-discs.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Persil Kapsule Original Forumla",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1999,
                        PictureUrl = "/images/products/persil-kapsule.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Perwoll Kapsule Black",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 2599,
                        PictureUrl = "/images/products/perwoll-kapsule.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Perwoll Kapsule Renew",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 3999,
                        PictureUrl = "/images/products/perwoll-kapsule-renew.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Silan Omekšivač Fresh",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 449,
                        PictureUrl = "/images/products/silan-fresh.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Silan Omekšivač Magnolia",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 467,
                        PictureUrl = "/images/products/silan-magnolia-32.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Sredstvo za čišćenje CIF Flower",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 321,
                        PictureUrl = "/images/products/sredstvo-za-ciscenje-cif-flower.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Tablete Fairy Platinum Big Pack",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 3999,
                        PictureUrl = "/images/products/tablete-fairy-platinum.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Tablete Finish All In 1 Max",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 6999,
                        PictureUrl = "/images/products/tablete-finish-ai1-one-max.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Tablete Somat Excellence GIGA Box",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 5999,
                        PictureUrl = "/images/products/tablete-somat-excellence.png",
                        Brand = "Kućna Hemija",
                        Type = "Hemija",
                        QuantityInStock = 100
                    },   
                    // Licna Higijena
                    new Product              
                    {
                        Name = "Dove Baby Bar Sapun",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 169,
                        PictureUrl = "/images/products/dove-baby-bar.png",
                        Brand = "Lična Higijena",
                        Type = "Dove",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Dove Coconut Milk Sapun",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 139,
                        PictureUrl = "/images/products/dove-coconut-milk.png",
                        Brand = "Lična Higijena",
                        Type = "Dove",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Dove Fresh Touch Lime Citrus Sapun",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 119,
                        PictureUrl = "/images/products/dove-fresh-touch.png",
                        Brand = "Lična Higijena",
                        Type = "Dove",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Dove Fresh Touch Sapun",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 139,
                        PictureUrl = "/images/products/dove-fresh-touch.png",
                        Brand = "Lična Higijena",
                        Type = "Dove",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Nivea Aloe Vera Flowers Sapun",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 149,
                        PictureUrl = "/images/products/nivea-aloe-vera-flowers.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Nivea Green Tea Cucumber Sapun",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 129,
                        PictureUrl = "/images/products/nivea-green-tea-cucumber.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Nivea LemonGrass And Oil Sapun",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 119,
                        PictureUrl = "/images/products/nivea-lemongrass-oil.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Palmolive Black Orchid Sapun",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 69,
                        PictureUrl = "/images/products/palmolive-black-orchid.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Palmolive Milk Honey Sapun",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 59,
                        PictureUrl = "/images/products/palmolive-milk-honey.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Losion Za Sunčanje Nivea",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1099,
                        PictureUrl = "/images/products/losion-za-suncanje-nivea.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Losion Za Sunčanje Nivea Sun",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 844,
                        PictureUrl = "/images/products/losion-za-suncanje-nivea-sun.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Mleko Za Sunčanje Carroten Kids Sprej 50",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1799,
                        PictureUrl = "/images/products/mleko-za-suncanje-carroten.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Carroten Mleko Za Sunčanje Sensicare 50+",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 999,
                        PictureUrl = "/images/products/mleko-za-suncanje-carroten-sensicare-spf50-200ml.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Sprej Nivea Protect Refresh",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 899,
                        PictureUrl = "/images/products/sprej-nivea-protect-refresh.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Sprej za sunčanje Nivea Sensitive",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 499,
                        PictureUrl = "/images/products/sprej-za-suncanje-nivea-sensitive.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pasta Za Zube Aquafresh Minty",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 220,
                        PictureUrl = "/images/products/pasta-aquafresh-fresh-minty.png",
                        Brand = "Lična Higijena",
                        Type = "Henkel",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pasta Za Zube Colgate Advanced",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 299,
                        PictureUrl = "/images/products/pasta-colgate-advanced.png",
                        Brand = "Lična Higijena",
                        Type = "Henkel",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pasta Za Zube Colgate Cavity Anti",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 389,
                        PictureUrl = "/images/products/pasta-colgate-cavity.png",
                        Brand = "Lična Higijena",
                        Type = "Henkel",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pasta Za Zube Colgate Cavity Protection",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 299,
                        PictureUrl = "/images/products/pasta-colgate-junior-cavity-protection.png",
                        Brand = "Lična Higijena",
                        Type = "Henkel",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pasta Za Zube Colgate Max Fresh",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 199,
                        PictureUrl = "/images/products/pasta-colgate-max-fresh.png",
                        Brand = "Lična Higijena",
                        Type = "Henkel",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pasta Za Zube Colgate Max White Crystals",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 499,
                        PictureUrl = "/images/products/pasta-colgate-max-white-crystal.png",
                        Brand = "Lična Higijena",
                        Type = "Henkel",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pasta Za Zube Colgate Max White Expert",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 299,
                        PictureUrl = "/images/products/pasta-colgate-max-white-expert.png",
                        Brand = "Lična Higijena",
                        Type = "Henkel",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pasta Za Zube Colgate Triple Action",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 289,
                        PictureUrl = "/images/products/pasta-colgate-triple-action.png",
                        Brand = "Lična Higijena",
                        Type = "Henkel",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Head&Shoulders 7in1",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 899,
                        PictureUrl = "/images/products/sampon-head-shoulders-7in1.png",
                        Brand = "Lična Higijena",
                        Type = "Henkel",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Head&Shoulders Citrus",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 899,
                        PictureUrl = "/images/products/sampon-head-shoulders-citrus.png",
                        Brand = "Lična Higijena",
                        Type = "Henkel",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Head&Shoulders Classic Clean",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 799,
                        PictureUrl = "/images/products/sampon-head-shoulders-classic-clean.png",
                        Brand = "Lična Higijena",
                        Type = "Henkel",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Head&Shoulders Derma X Pro",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 999,
                        PictureUrl = "/images/products/sampon-head-shoulders-derma-x-pro.png",
                        Brand = "Lična Higijena",
                        Type = "Henkel",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Šampon Nivea Micellar Diamond Volume Care",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 444,
                        PictureUrl = "/images/products/sampon-nivea-diamond-volume-care.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Šampon Nivea Micellar Green",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 549,
                        PictureUrl = "/images/products/sampon-nivea-micellar.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",

                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Šampon Nivea Micellar Opium",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 555,
                        PictureUrl = "/images/products/sampon-nivea-micellar-o.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Wash&Go Šampon AloeVera",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 689,
                        PictureUrl = "/images/products/sampon-wash-go-aloe.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Wash&Go Šampon Herbal Cocktail",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 599,
                        PictureUrl = "/images/products/sampon-wash-go-herbal-coctail.png",
                        Brand = "Lična Higijena",
                        Type = "Henkel",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Šampon Wash And Go Micelarni",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 699,
                        PictureUrl = "/images/products/sampon-wash-go-micelarni.png",
                        Brand = "Lična Higijena",
                        Type = "Henkel",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Gel Za Tuširanje Tuširanje Dove",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 899,
                        PictureUrl = "/images/products/gel-za-tusiranje-dove.png",
                        Brand = "Lična Higijena",
                        Type = "Henkel",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Gel Za Tuširanje Dove Deeply Cream",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 599,
                        PictureUrl = "/images/products/gel-za-tusiranje-dove-deeply.png",
                        Brand = "Lična Higijena",
                        Type = "Dove",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Gel Za Tuširanje Nivea Energy",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 799,
                        PictureUrl = "/images/products/gel-za-tusiranje-nivea-energy.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Gel Za Tuširanje Nivea Frangipani",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 999,
                        PictureUrl = "/images/products/gel-za-tusiranje-nivea-frangipani.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Gel Za Tuširanje Nivea Men Deep",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 699,
                        PictureUrl = "/images/products/gel-za-tusiranje-nivea-men-deep.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Gel Za Tuširanje Pure Fresh Blue",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 479,
                        PictureUrl = "/images/products/gel-za-tusiranje-nivea-pure-fresh.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Gel Za Tuširanje Nivea Silver ",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 699,
                        PictureUrl = "/images/products/gel-za-tusiranje-nivea-silver.png",
                        Brand = "Lična Higijena",
                        Type = "Nivea",
                        QuantityInStock = 100
                    },           
                    //Pice
                    new Product              
                    {
                        Name = "Gazirana Voda Heba",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 89,
                        PictureUrl = "/images/products/gazirana-voda-heba.png",
                        Brand = "Piće",
                        Type = "VodaVoda",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Gazirana Voda Knjaz Miloš",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 99,
                        PictureUrl = "/images/products/gazirana-voda-knjaz-milos.png",
                        Brand = "Piće",
                        Type = "VodaVoda",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Gazirana Voda Minaqua",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 119,
                        PictureUrl = "/images/products/gazirana-voda-minaqua.png",
                        Brand = "Piće",
                        Type = "VodaVoda",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Gazirana Voda Rosa",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 119,
                        PictureUrl = "/images/products/gazirana-voda-rosa.png",
                        Brand = "Piće",
                        Type = "VodaVoda",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Voda AquaViva",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 59,
                        PictureUrl = "/images/products/voda-aqua-viva.png",
                        Brand = "Piće",
                        Type = "VodaVoda",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Voda Jazak",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 139,
                        PictureUrl = "/images/products/voda-jazak.png",
                        Brand = "Piće",
                        Type = "VodaVoda",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Voda Mivela Mg",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 112,
                        PictureUrl = "/images/products/voda-mivela.png",
                        Brand = "Piće",
                        Type = "VodaVoda",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Voda Prolom",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 56,
                        PictureUrl = "/images/products/voda-prolom.png",
                        Brand = "Piće",
                        Type = "VodaVoda",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Voda Rosa",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 44,
                        PictureUrl = "/images/products/voda-ross.png",
                        Brand = "Piće",
                        Type = "VodaVoda",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Crno Vino Aleksić Kardaš",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 899,
                        PictureUrl = "/images/products/belo-vino-aleksic-kardas.png",
                        Brand = "Piće",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Belo Vino Aleksić Sevdah",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 670,
                        PictureUrl = "/images/products/belo-vino-aleksic-sevdah.png",
                        Brand = "Piće",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Belo Vino Kovačević",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 799,
                        PictureUrl = "/images/products/belo-vino-kovacevic.png",
                        Brand = "Piće",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Belo Vino Planta Za Chardon",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1099,
                        PictureUrl = "/images/products/belo-vino-plantaze-chardon.png",
                        Brand = "Piće",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Belo Vino Zvonko Bogdan Osam Tamburaša",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1199,
                        PictureUrl = "/images/products/belo-vino-zvonko-bogdan-osam-tamburasa.png",
                        Brand = "Piće",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Belo Vino Zvonko Bogdan Pinot Blanc",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1199,
                        PictureUrl = "/images/products/belo-vino-zvonko-bogdan-pinot-blanc.png",
                        Brand = "Piće",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Crno Vino Aleksić Nostalgija",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 799,
                        PictureUrl = "/images/products/crno-vino-aleksic-nostalgija.png",
                        Brand = "Piće",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },  
                    new Product              
                    {
                        Name = "Crno Vino Aleksić Cabrenet Sauvignon",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 799,
                        PictureUrl = "/images/products/crno-vino-cabernet-sauvignon.png",
                        Brand = "Piće",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Penušavo Vino Prosecco",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1099,
                        PictureUrl = "/images/products/penusavo-vino-prosecco.png",
                        Brand = "Piće",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Aleksić Roze Barbara",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 599,
                        PictureUrl = "/images/products/rose-aleksic-barbara.png",
                        Brand = "Piće",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Erdevik Roze Tri Roze Koze",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 999,
                        PictureUrl = "/images/products/roze-erdevik-tri-koze-roze.png",
                        Brand = "Piće",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Roze Vino Doja Cat",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1499,
                        PictureUrl = "/images/products/roze-vino-doja.png",
                        Brand = "Piće",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Roze Vino Zvonko Bogdan 4 Konja Debela",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1199,
                        PictureUrl = "/images/products/roze-zvonko-bogdan.png",
                        Brand = "Piće",
                        Type = "Ukusi Italije",
                        QuantityInStock = 100
                    },  
                    new Product              
                    {
                        Name = "Dzin Beefeater",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1399,
                        PictureUrl = "/images/products/dzin-beefeater.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Dzin Beefeater Pink",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1599,
                        PictureUrl = "/images/products/dzin-beefeater-pink.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           

                    new Product              
                    {
                        Name = "Dzin Hendricks",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 3199,
                        PictureUrl = "/images/products/dzin-hendricks.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Dzin Tanqueray",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 5199,
                        PictureUrl = "/images/products/dzin-tanqueray.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Liker Aperol",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 2299,
                        PictureUrl = "/images/products/liker-aperol.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Liker Baileys Jagoda I Krem",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 3399,
                        PictureUrl = "/images/products/liker-baileys-jagoda-i-krem.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Liker Campari",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 2299,
                        PictureUrl = "/images/products/liker-campari.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Liker Jagermeister",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 2499,
                        PictureUrl = "/images/products/liker-jagermeister.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Liker BlueCuracao",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1599,
                        PictureUrl = "/images/products/liker-marie-blue-curacao.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Liker Triple-Sec",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1599,
                        PictureUrl = "/images/products/liker-marie-triple-ses.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Rakija Vučija Dunja",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 3300,
                        PictureUrl = "/images/products/rakija-dunja.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Rakija Vučija Kajsija",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 3300,
                        PictureUrl = "/images/products/rakija-kajsija.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Rakija Vučija Šljiva",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 3300,
                        PictureUrl = "/images/products/rakija-sljiva.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Rakija Vučija Viljamovka",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 3300,
                        PictureUrl = "/images/products/rakija-viljamovka.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           

                    new Product              
                    {
                        Name = "Rum Bacardi",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 2799,
                        PictureUrl = "/images/products/rum-bacardi.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           

                    new Product              
                    {
                        Name = "Rum Captain Morgan",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1999,
                        PictureUrl = "/images/products/rum-captain-morgan.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           

                    new Product              
                    {
                        Name = "Rum Havana Club",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1699,
                        PictureUrl = "/images/products/rum-havana-club.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           

                    new Product              
                    {
                        Name = "Rum Malibu",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1100,
                        PictureUrl = "/images/products/rum-malibu.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           

                    new Product              
                    {
                        Name = "Tekila Blanco",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 2499,
                        PictureUrl = "/images/products/tekila-blanco.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },           

                    new Product              
                    {
                        Name = "Tekila Two Fingers",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 1399,
                        PictureUrl = "/images/products/tekila-two-fingers.png",
                        Brand = "Piće",
                        Type = "Žestina",
                        QuantityInStock = 100
                    },                                     
                    new Product              
                    {
                        Name = "Voćni Sok Nectar Family Šumsko Voće",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 229,
                        PictureUrl = "/images/products/vocni-sok-nectar-family-vocni.png",
                        Brand = "Piće",
                        Type = "Nectar",
                        QuantityInStock = 100
                    },           

                    new Product              
                    {
                        Name = "Voćni Sok Nectar Family Pomorandza",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 239,
                        PictureUrl = "/images/products/vocni-sok-nectar-family-pomorandza.png",
                        Brand = "Piće",
                        Type = "Nectar",
                        QuantityInStock = 100
                    },           

                    new Product              
                    {
                        Name = "Voćni Sok Nectar Family Jagoda",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 229,
                        PictureUrl = "/images/products/vocni-sok-nectar-family-jagoda.png",
                        Brand = "Piće",
                        Type = "Nectar",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Voćni Sok Nectar Family Ananas",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 279,
                        PictureUrl = "/images/products/vocni-sok-nectar-family-ananas.png",
                        Brand = "Piće",
                        Type = "Nectar",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Voćni Sok Nectar Family Jabuka",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 219,
                        PictureUrl = "/images/products/vocni-sok-nectar-family-jabuka.png",
                        Brand = "Piće",
                        Type = "Nectar",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Voćni Sok Fruvita Permium Jabuka",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 249,
                        PictureUrl = "/images/products/vocni-sok-fruvita-premium-jablim.png",
                        Brand = "Piće",
                        Type = "Nectar",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Voćni Sok Fruvita Permium Breskva",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 249,
                        PictureUrl = "/images/products/vocni-sok-fruvita-premium-breskva.png",
                        Brand = "Piće",
                        Type = "Nectar",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pivo Amstel",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 119,
                        PictureUrl = "/images/products/amstel.png",
                        Brand = "Piće",

                        Type = "CrowBrewery",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pivo Becks",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 99,
                        PictureUrl = "/images/products/becks.png",
                        Brand = "Piće",
                        Type = "CrowBrewery",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pivo Birra Moreti",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 125,
                        PictureUrl = "/images/products/birra-moretti.png",
                        Brand = "Piće",
                        Type = "CrowBrewery",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pivo Blanc",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 119,
                        PictureUrl = "/images/products/blanc.png",
                        Brand = "Piće",
                        Type = "CrowBrewery",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pivo Budweiser",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 109,
                        PictureUrl = "/images/products/budweiser.png",
                        Brand = "Piće",
                        Type = "CrowBrewery",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pivo Carlsberg",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 149,
                        PictureUrl = "/images/products/carlsberg.png",
                        Brand = "Piće",
                        Type = "CrowBrewery",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pivo Erdinger",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 139,
                        PictureUrl = "/images/products/erdinger.png",
                        Brand = "Piće",
                        Type = "CrowBrewery",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pivo Heineken",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 119,
                        PictureUrl = "/images/products/heineken.png",
                        Brand = "Piće",
                        Type = "CrowBrewery",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pivo Jelen",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 69,
                        PictureUrl = "/images/products/jelen.png",
                        Brand = "Piće",
                        Type = "CrowBrewery",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pivo Nektar",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 79,
                        PictureUrl = "/images/products/nektar.png",
                        Brand = "Piće",
                        Type = "CrowBrewery",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pivo Nikšićko",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 139,
                        PictureUrl = "/images/products/niksicko.png",
                        Brand = "Piće",
                        Type = "CrowBrewery",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pivo Pilsner",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 139,
                        PictureUrl = "/images/products/pilsner.png",
                        Brand = "Piće",
                        Type = "CrowBrewery",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pivo Staropramen",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 99,
                        PictureUrl = "/images/products/staropramen.png",
                        Brand = "Piće",
                        Type = "CrowBrewery",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Pivo Stella Artois",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 129,
                        PictureUrl = "/images/products/stella.png",
                        Brand = "Piće",
                        Type = "CrowBrewery",
                        QuantityInStock = 100
                    },           
                    new Product              
                    {
                        Name = "Coca-Cola 2l",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 199,
                        PictureUrl = "/images/products/coca-cola.png",
                        Brand = "Piće",
                        Type = "CocaColaCompnay",
                        QuantityInStock = 100
                    },                  
                    new Product              
                    {
                        Name = "Cockta 2l",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 99,
                        PictureUrl = "/images/products/cockta.png",
                        Brand = "Piće",
                        Type = "CocaColaCompnay",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Fanta Exotic",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 145,
                        PictureUrl = "/images/products/fanta-exotic.png",
                        Brand = "Piće",
                        Type = "CocaColaCompnay",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Fanta Lemon",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 188,
                        PictureUrl = "/images/products/fanta-lemon.png",
                        Brand = "Piće",
                        Type = "CocaColaCompnay",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Fanta Pomorandza 2l",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 129,
                        PictureUrl = "/images/products/fanta-pomorandza.png",
                        Brand = "Piće",
                        Type = "CocaColaCompnay",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Fanta Shokata 2l",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 177,
                        PictureUrl = "/images/products/fanta-shokata.png",
                        Brand = "Piće",
                        Type = "CocaColaCompnay",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Pepsi MAX 2l",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 129,
                        PictureUrl = "/images/products/pepsi.png",
                        Brand = "Piće",
                        Type = "CocaColaCompnay",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Schweppes",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 129,
                        PictureUrl = "/images/products/schweppes.png",
                        Brand = "Piće",
                        Type = "CocaColaCompnay",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Sprite",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 144,
                        PictureUrl = "/images/products/sprite.png",
                        Brand = "Piće",
                        Type = "CocaColaCompnay",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Pepsi Twist",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 105,
                        PictureUrl = "/images/products/twist.png",
                        Brand = "Piće",
                        Type = "CocaColaCompnay",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Milford Berries",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 105,
                        PictureUrl = "/images/products/milford-berry.png",
                        Brand = "Piće",
                        Type = "CocaColaCompnay",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Milford Fruits",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 165,
                        PictureUrl = "/images/products/milford-fruits.png",
                        Brand = "Piće",
                        Type = "CocaColaCompnay",
                        QuantityInStock = 100
                    },   

                    new Product              
                    {
                        Name = "Milford Snow Delight",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 125,
                        PictureUrl = "/images/products/milford-snow.png",
                        Brand = "Piće",
                        Type = "CocaColaCompnay",
                        QuantityInStock = 100
                    },   

                    new Product              
                    {
                        Name = "Milford Jagoda Jogurt",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 115,
                        PictureUrl = "/images/products/milford-strawberry.png",
                        Brand = "Piće",
                        Type = "CocaColaCompnay",
                        QuantityInStock = 100
                    },   

                    new Product              
                    {
                        Name = "Milford Zeleni Čaj",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 125,
                        PictureUrl = "/images/products/zeleni-caj-milford.png",
                        Brand = "Piće",
                        Type = "CocaColaCompnay",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Booster Grapefruit",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 59,
                        PictureUrl = "/images/products/booster-grapefruit.png",
                        Brand = "Piće",
                        Type = "CocaColaCompany",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Booster Mango",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 69,
                        PictureUrl = "/images/products/booster-mango.png",
                        Brand = "Piće",
                        Type = "CocaColaCompany",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Booster Reboost",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 79,
                        PictureUrl = "/images/products/booster-reboost.png",
                        Brand = "Piće",
                        Type = "CocaColaCompany",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Gurana Original",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 59,
                        PictureUrl = "/images/products/guarana-500ml.png",
                        Brand = "Piće",
                        Type = "CocaColaCompany",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Gurana Cactus",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 69,
                        PictureUrl = "/images/products/guarana-cactus.png",
                        Brand = "Piće",
                        Type = "CocaColaCompany",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "Hell Classic",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 89,
                        PictureUrl = "/images/products/hell-classic.png",
                        Brand = "Piće",
                        Type = "CocaColaCompany",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "RedBull 250ml Original",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 124,
                        PictureUrl = "/images/products/red-bull.png",
                        Brand = "Piće",
                        Type = "CocaColaCompany",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "RedBull 2pack",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 299,
                        PictureUrl = "/images/products/red-bull-2pack.png",
                        Brand = "Piće",
                        Type = "CocaColaCompany",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "RedBull Lubenica",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 139,
                        PictureUrl = "/images/products/red-bull-lubenica.png",
                        Brand = "Piće",
                        Type = "CocaColaCompany",
                        QuantityInStock = 100
                    },   
                    new Product              
                    {
                        Name = "RedBull Sugar Free 250ml",
                        Description =
                            "Suspendisse dui purus, scelerisque at, vulputate vitae, pretium mattis, nunc. Mauris eget neque at sem venenatis eleifend. Ut nonummy.",
                        Price = 119,
                        PictureUrl = "/images/products/red-bull-sugar-free.png",
                        Brand = "Piće",
                        Type = "CocaColaCompany",
                        QuantityInStock = 100
                    },   
            };
 
            foreach (var product in products)
            {
                context.Products.Add(product);
            }

            context.SaveChanges();

        }
    }
}
