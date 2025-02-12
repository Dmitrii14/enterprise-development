using Microsoft.EntityFrameworkCore;

namespace NonResidentialFund.Domain;
/// <summary>
/// NonResidentialFundContext - represents a DbContext for the application
/// </summary>
public sealed class NonResidentialFundContext : DbContext
{
    /// <summary>
    /// Auctions - Represents a collection of Auction objects in the database
    /// </summary>
    public DbSet<Auction> Auctions { get; set; }

    /// <summary>
    /// Buildings - Represents a collection of Building objects in the database
    /// </summary>
    public DbSet<Building> Buildings { get; set; }

    /// <summary>
    /// BuildingAuctionConnections - Represents a collection of BuildingAuctionConnections objects in the database
    /// </summary>
    public DbSet<BuildingAuctionConnection> BuildingAuctionConnections { get; set; }

    /// <summary>
    /// Buyers - Represents a collection of Buyer objects in the database
    /// </summary>
    public DbSet<Buyer> Buyers { get; set; }

    /// <summary>
    /// BuyerAuctionConnections - Represents a collection of BuyerAuctionConnection objects in the database
    /// </summary>
    public DbSet<BuyerAuctionConnection> BuyerAuctionConnections { get; set; }

    /// <summary>
    /// Districts - Represents a collection of District objects in the database
    /// </summary>
    public DbSet<District> Districts { get; set; }

    /// <summary>
    /// Organizations - Represents a collection of Organizations objects in the database
    /// </summary>
    public DbSet<Organization> Organizations { get; set; }

    /// <summary>
    /// Privatized - Represents a collection of Privatized buildings objects in the database
    /// </summary>
    public DbSet<Privatized> Privatized { get; set; }

    /// <summary>
    /// Constructor of NonResidentialFundContext
    /// </summary>
    /// <param name="options">Parameter for NonResidentialFundContext</param>
    public NonResidentialFundContext(DbContextOptions options) : base(options)
    {
        Database.EnsureCreated();
    }

    /// <summary>
    /// DistrictRepository - collection of Distruct objects, which is used to be add into database when it created
    /// </summary>
    private static List<District> DistrictRepository =>
        new()
        {
            new()
            {
                DistrictId = 1,
                DistrictName = "Промышленный"
            },
            new()
            {
                DistrictId = 2,
                DistrictName = "Кировский"
            },
            new()
            {
                DistrictId = 3,
                DistrictName = "Советский"
            },
            new()
            {
                DistrictId = 4,
                DistrictName = "Октябрьский"
            },
            new()
            {
                DistrictId = 5,
                DistrictName = "Куйбышевский"
            },
            new()
            {
                DistrictId=6,
                DistrictName="Железнодорожный"
            }
        };


    /// <summary>
    /// OrganizationRepository - collection of Organization objects, which is used to be add into database when it created
    /// </summary>
    private static List<Organization> OrganizationRepository =>
        new()
        {
            new()
            {
                OrganizationId = 1,
                OrganizationName = "СамараИнвест"
            },
            new()
            {
                OrganizationId = 2,
                OrganizationName = "ОАО Аукцион"
            },
            new()
            {
                OrganizationId = 3,
                OrganizationName = "Имущественные торги"
            },
		    new() 
		    {
			    OrganizationId=4, 
			    OrganizationName="Самара Тендер" 
		    },
    	    new() 
    	    {
    		    OrganizationId=5, 
    		    OrganizationName="АО Сбербанк-АСТ" 
    	    },
    	    new() 
    	    {
                OrganizationId=6, 
    	        OrganizationName="АО ЕЭТП"
    	    }
        };


    /// <summary>
    /// BuyerRepository - collection of Buyer objects, which is used to be add into database when it created
    /// </summary>
    private static List<Buyer> BuyerRepository =>
        new()
        {
            new()
            {
                BuyerId = 1,
                LastName = "Мизягин",
                FirstName = "Евгений",
                MiddleName = "Викторович",
                PassportSeries = "3716",
                PassportNumber = "928715",
                Address = "г. Самара ул. Московское шоссе 252 кв. 186"
            },
            new()
            {
                BuyerId = 2,
                LastName = "Грачев",
                FirstName = "Михаил",
                MiddleName = "Александрович",
                PassportSeries = "6251",
                PassportNumber = "629574",
                Address = "г. Сызрань ул. Советская 15 кв. 3"
            },
            new()
            {
                BuyerId = 3,
                LastName = "Подлипаев",
                FirstName = "Олег",
                MiddleName = "Викторович",
                PassportSeries = "6295",
                PassportNumber = "746153",
                Address = "г. Новокуйбышевск ул. Советская 71 кв. 13"
            },
            new()
            {
                BuyerId = 4,
                LastName = "Корнеев",
                FirstName = "Николай",
                MiddleName = "Игоревич",
                PassportSeries = "9462",
                PassportNumber = "745625",
                Address = "г. Самара ул. Ново-садовая 25 кв. 77"
            },
            new()
            {
                BuyerId = 5,
                LastName = "Чубрин",
                    FirstName = "Александр",
                MiddleName = "Андреевич",
                PassportSeries = "8572",
                PassportNumber = "547296",
                Address = "г. Самара ул. Авроры 52 кв. 11"
            },
            new()
            {
                BuyerId = 6,
                LastName = "Сомова",
                    FirstName = "Надежда",
                MiddleName = "Николаевна",
                PassportSeries = "6356",
                PassportNumber = "782546",
                Address = "г. Новокуйбышевск ул. Карла Маркса 81 кв. 39"
            },
            new()
            {
                BuyerId = 7,
                LastName = "Мочалов",
                    FirstName = "Андрей",
                MiddleName = "Сергеевич",
                PassportSeries = "6567",
                PassportNumber = "856456",
                Address = "г. Сызрань ул. Подшипниковая 12 кв. 2"
            },
            new()
            {
                BuyerId = 8,
                LastName = "Аскерова",
                FirstName = "Вера",
                MiddleName = "Игоревна",
                PassportSeries = "7145",
                PassportNumber = "624256",
                Address = "г. Самара ул. Фадеева 1 кв. 54"
            }
        };


    /// <summary>
    /// BuildingRepository - collection of Building objects, which is used to be add into database when it created
    /// </summary>
    private static List<Building> BuildingRepository =>
        new()
        {
            new()
            {
                RegistrationNumber = 1,
                Address = "Ул. Московскосе шоссе д. 22 кв. 8",
                DistrictId = 1,
                Area = 43.9,
                FloorCount = 9,
                BuildDate =  new DateTime(1980, 1, 10)
            },
            new()
            {
                RegistrationNumber = 2,
                Address = "Ул. Ново-вокзальная д. 1 кв. 19",
                DistrictId = 1,
                Area = 63.0,
                FloorCount = 9,
                BuildDate = new DateTime(1988, 10, 21)
            },
            new()
            {
                RegistrationNumber = 3,
                Address = "Ул. Фадеева д. 62",
                DistrictId = 1,
                Area = 1243.9,
                FloorCount =  2,
                BuildDate =  new DateTime(1966, 6, 1)
            },
            new()
            {
                RegistrationNumber = 4,
                Address = "Ул. Стара-Загора д. 78 кв. 41",
                DistrictId = 1,
                Area = 98.3,
                FloorCount = 12,
                BuildDate = new DateTime(1978, 6,13)
            },
            new()
            {
                RegistrationNumber = 5,
                Address = "Ул. Cолнечная д. 30",
                DistrictId = 1,
                Area = 298.3,
                FloorCount = 12,
                BuildDate = new DateTime(2006, 3, 1)
            },
            new()
            {
                RegistrationNumber = 6,
                Address = "Ул. Ставропольская д. 214 кв. 8",
                DistrictId = 2,
                Area = 33.9,
                FloorCount = 16,
                BuildDate = new DateTime(2007,10,11)
            },
            new()
            {
                RegistrationNumber = 7,
                Address = "Ул. Советская д. 119 кв. 1",
                DistrictId = 2,
                Area = 43.0,
                FloorCount = 2,
                BuildDate = new DateTime(1941, 3, 3)
            },
            new()
            {
                RegistrationNumber = 8,
                Address = "Ул. Мирная д. 165",
                DistrictId = 2,
                Area = 283.9,
                FloorCount = 2,
                BuildDate = new DateTime(2003, 7, 13)
            },
            new()
            {
                RegistrationNumber = 9,
                Address = "Ул. Черемшанская д. 158 кв. 41",
                DistrictId = 2,
                Area = 112.3,
                FloorCount = 5,
                BuildDate = new DateTime(1973, 5, 30)
            },
            new()
            {
                RegistrationNumber = 10,
                Address = "Ул. Юнных пионеров д. 154А",
                DistrictId = 2,
                Area = 2482.3,
                FloorCount = 3,
                BuildDate = new DateTime(1969, 12, 30)
            }
        };


    /// <summary>
    /// PrivatizedRepository - collection of Privatized building objects, which is used to be add into database when it created
    /// </summary>
    private static List<Privatized> PrivatizedRepository =>
        new()
        {
            new()
            {
                RegistrationNumber = 1,
                BuyerId = 1,
                AuctionId = 1,
                SaleDate = new DateTime(2022, 3, 17),
                StartPrice = 615827.99,
                EndPrice = 1297618.13
            },
            new()
            {
                RegistrationNumber = 2,
                BuyerId = 4,
                AuctionId = 2,
                SaleDate = new DateTime(2022, 3, 17),
                StartPrice = 862100.93,
                EndPrice = 1231971.10
            },
            new()
            {
                RegistrationNumber = 3,
                BuyerId = 8,
                AuctionId = 3,
                SaleDate = new DateTime(2022, 3, 17),
                StartPrice = 1062109.00,
                EndPrice = 14301872.17
            },
            new()
            {
                RegistrationNumber = 7,
                BuyerId = 2,
                AuctionId = 5,
                SaleDate = new DateTime(2022, 3, 17),
                StartPrice = 1846378.72,
                EndPrice = 2647635.37
            },
            new()
            {
                RegistrationNumber = 8,
                BuyerId = 1,
                AuctionId = 8,
                SaleDate = new DateTime(2022, 3, 20),
                StartPrice = 628476.17,
                EndPrice = 964372.09
            },
            new()
            {
                RegistrationNumber = 9,
                BuyerId = 8,
                AuctionId = 7,
                SaleDate = new DateTime(2022, 3, 19),
                StartPrice = 2657387.93,
                EndPrice = 4726478.00
            }
        };


    /// <summary>
    /// AuctionRepository - collection of Auction objects, which is used to be add into database when it created
    /// </summary>
    private static List<Auction> AuctionRepository =>
        new()
        {
            new()
            {
                AuctionId = 1,
                Date = new DateTime(2022, 3, 17),
                OrganizationId = 1
            },
            new()
            {
                AuctionId = 2,
                Date = new DateTime(2022, 3, 17),
                OrganizationId = 3
            },
            new()
            {
                AuctionId = 3,
                Date = new DateTime(2022, 3, 17),
                OrganizationId = 7
            },
            new()
            {
                AuctionId = 4,
                Date = new DateTime(2022, 3, 17),
                OrganizationId = 8
            },
            new()
            {
                AuctionId = 5,
                Date = new DateTime(2022, 3, 17),
                OrganizationId = 4
            },
            new()
            {
                AuctionId = 6,
                Date = new DateTime(2022, 3, 17),
                OrganizationId = 2
            },
            new()
            {
                AuctionId = 7,
                Date = new DateTime(2022, 3, 19),
                OrganizationId = 1
            },
            new()
            {
                AuctionId = 8,
                Date = new DateTime(2022, 3, 20),
                OrganizationId = 7
            },
            new()
            {
                AuctionId = 9,
                Date = new DateTime(2022, 3, 21),
                OrganizationId = 2
            },
            new()
            {
                AuctionId = 10,
                Date = new DateTime(2022, 3, 21),
                OrganizationId = 3
            }
        };


    /// <summary>
    /// BuildingAuctionConnectionRepository - collection of BuildingAuctionConnection objects, which is used to be add into database when it created
    /// </summary>
    private static List<BuildingAuctionConnection> BuildingAuctionConnectionRepository =>
        new()
        {       
            new() {Id = 1, BuildingId = 1, AuctionId = 1 },
            new() {Id = 2, BuildingId = 2, AuctionId = 2 },
            new() {Id = 3, BuildingId = 3, AuctionId = 3 },
            new() {Id = 4, BuildingId = 4, AuctionId = 5 },
            new() {Id = 5, BuildingId = 5, AuctionId = 4 },
            new() {Id = 6, BuildingId = 5, AuctionId = 10 },
            new() {Id = 7, BuildingId = 7, AuctionId = 5 },
            new() {Id = 8, BuildingId = 8, AuctionId = 6 },
            new() {Id = 9,  BuildingId = 8, AuctionId = 8 },
            new() {Id = 10,  BuildingId = 9, AuctionId = 1 },
            new() {Id = 11,  BuildingId = 9, AuctionId = 7 },
            new() {Id = 12,  BuildingId = 10, AuctionId = 4 },
            new() {Id = 13,  BuildingId = 10, AuctionId = 9 }
        };


    /// <summary>
    /// BuyerAuctionConnectionRepository - collection of BuyerAuctionConnection objects, which is used to be add into database when it created
    /// </summary>
    private static List<BuyerAuctionConnection> BuyerAuctionConnectionRepository =>
        new()
        {
            
            new() {Id = 1, BuyerId = 1, AuctionId = 1 },
            new() {Id = 2, BuyerId = 1, AuctionId = 5 },
            new() {Id = 3, BuyerId = 1, AuctionId = 6 },
            new() {Id = 4, BuyerId = 1, AuctionId = 7 },
            new() {Id = 5, BuyerId = 1, AuctionId = 8 },
            new() {Id = 6, BuyerId = 1, AuctionId = 10},
            new() {Id = 7, BuyerId = 2, AuctionId = 1 },
            new() {Id = 8, BuyerId = 2, AuctionId = 5 },
            new() {Id = 9, BuyerId = 2, AuctionId = 6 },
            new() {Id = 10, BuyerId = 2, AuctionId = 7 },
            new(){Id = 11, BuyerId = 2, AuctionId = 8 },
            new() {Id = 12, BuyerId = 3, AuctionId = 4 },
            new() {Id = 13, BuyerId = 3, AuctionId = 5 },
            new() {Id = 14, BuyerId = 3, AuctionId = 7 },
            new() {Id = 15, BuyerId = 3, AuctionId = 8 },
            new(){Id = 16, BuyerId = 3, AuctionId = 9 },
            new() {Id = 17, BuyerId = 4, AuctionId = 2 },
            new() {Id = 18, BuyerId = 4, AuctionId = 5 },
            new() {Id = 19, BuyerId = 4, AuctionId = 7 },
            new() {Id = 20, BuyerId = 4, AuctionId = 8 },
            new() {Id = 21, BuyerId = 4, AuctionId = 10 },
            new() {Id = 22, BuyerId = 5, AuctionId = 2 },
            new() {Id = 23, BuyerId = 5, AuctionId = 5 },
            new() {Id = 24, BuyerId = 5, AuctionId = 7 },
            new() {Id = 25, BuyerId = 5, AuctionId = 8 },
            new() {Id = 26, BuyerId = 6, AuctionId = 4 },
            new() {Id = 27, BuyerId = 6, AuctionId = 5 },
            new() {Id = 28, BuyerId = 6, AuctionId = 7 },
            new() {Id = 29, BuyerId = 6, AuctionId = 8 },
            new() {Id = 30, BuyerId = 7, AuctionId = 3 },
            new() {Id = 31, BuyerId = 7, AuctionId = 5 },
            new() {Id = 32, BuyerId = 7, AuctionId = 7 },
            new() {Id = 33, BuyerId = 7, AuctionId = 8 },
            new() {Id = 34, BuyerId = 7, AuctionId = 9 },
            new() {Id = 35, BuyerId = 8, AuctionId = 3 },
            new() {Id = 36, BuyerId = 8, AuctionId = 5 },
            new() {Id = 37, BuyerId = 8, AuctionId = 7 },
            new() {Id = 38, BuyerId = 8, AuctionId = 8 },
            new() {Id = 39, BuyerId = 8, AuctionId = 10 }
        };


    /// <summary>
    /// Configures structure of database
    /// Inserts data into the database
    /// </summary>
    /// <param name="modelBuilder">Object for configuring the database</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BuildingAuctionConnection>().HasKey(connection => new { connection.BuildingId, connection.AuctionId });

        foreach (var district in DistrictRepository)
        {
            modelBuilder.Entity<District>().HasData(district);
        }
        foreach (var organization in OrganizationRepository)
        {
            modelBuilder.Entity<Organization>().HasData(organization);
        }
        foreach (var buyer in BuyerRepository)
        {
            modelBuilder.Entity<Buyer>().HasData(buyer);
        }
        foreach (var building in BuildingRepository)
        {
            modelBuilder.Entity<Building>().HasData(building);
        }
        foreach (var privatized in PrivatizedRepository)
        {
            modelBuilder.Entity<Privatized>().HasData(privatized);
        }
        foreach (var auction in AuctionRepository)
        {
            modelBuilder.Entity<Auction>().HasData(auction);
        }
        foreach (var buildingAuctionConnection in BuildingAuctionConnectionRepository)
        {
            modelBuilder.Entity<BuildingAuctionConnection>().HasData(buildingAuctionConnection);
        }
        foreach (var buyerAuctionRepository in BuyerAuctionConnectionRepository)
        {
            modelBuilder.Entity<BuyerAuctionConnection>().HasData(buyerAuctionRepository);
        }
    }
};