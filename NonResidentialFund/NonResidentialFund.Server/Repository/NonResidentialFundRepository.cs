﻿using NonResidentialFund.Domain;

namespace NonResidentialFund.Server.Repository;

/// <summary>
/// Repository class for managing non-residential fund data.
/// </summary>
public class NonResidentialFundRepository : INonResidentialFundRepository
{
    private readonly List<District> _districts;
    private readonly List<Organization> _organizations;
    private readonly List<Buyer> _buyers;
    private readonly List<Building> _buildings;
    private readonly List<Privatized> _privatized;
    private readonly List<Auction> _auctions;

    /// <summary>
    /// Initializes a new instance of the <see cref="NonResidentialFundRepository"/> class.
    /// </summary>
    public NonResidentialFundRepository()
    {
        _districts = new List<District> {
            new District(1, "Промышленный"),
            new District(2, "Кировский"),
            new District(3, "Советский"),
            new District(4, "Октябрьский"),
            new District(5, "Куйбышевский"),
            new District(6, "Железнодорожный")
        };

        _organizations = new List<Organization>{
            new Organization(1, "СамараИнвест"),
            new Organization(2, "ОАО Аукцион"),
            new Organization(3, "Имущественные торги"),
            new Organization(4, "Самара Тендер"),
            new Organization(5, "АО Сбербанк-АСТ"),
            new Organization(6, "АО ЕЭТП")
        };

        _buyers = new List<Buyer> {
            new Buyer(1, "Мизягин", "Евгений", "Викторович", "3716", "928715", "г. Самара ул. Московское шоссе 252 кв. 186",
                new List<BuyerAuctionConnection>
                {
                    new BuyerAuctionConnection(1, 1),
                    new BuyerAuctionConnection(1, 5),
                    new BuyerAuctionConnection(1, 6),
                    new BuyerAuctionConnection(1, 7),
                    new BuyerAuctionConnection(1, 8),
                    new BuyerAuctionConnection(1, 10)

                }),
            new Buyer(2, "Грачев", "Михаил", "Александрович", "6251", "629574", "г. Сызрань ул. Советская 15 кв. 3",
                new List<BuyerAuctionConnection>
                {
                    new BuyerAuctionConnection(2, 1),
                    new BuyerAuctionConnection(2, 5),
                    new BuyerAuctionConnection(2, 6),
                    new BuyerAuctionConnection(2, 7),
                    new BuyerAuctionConnection(2, 8),
                }),
            new Buyer(3, "Подлипаев", "Олег", "Викторович", "6295", "746153", "г. Новокуйбышевск ул. Советская 71 кв. 13",
                new List < BuyerAuctionConnection > {
                    new BuyerAuctionConnection(3, 4),
                    new BuyerAuctionConnection(3, 5),
                    new BuyerAuctionConnection(3, 7),
                    new BuyerAuctionConnection(3, 8),
                    new BuyerAuctionConnection(3, 9),
                }),
            new Buyer(4, "Корнеев", "Николай", "Игоревич", "9462", "745625", "г. Самара ул. Ново-садовая 25 кв. 77",
                new List < BuyerAuctionConnection > {
                    new BuyerAuctionConnection(4, 2),
                    new BuyerAuctionConnection(4, 5),
                    new BuyerAuctionConnection(4, 7),
                    new BuyerAuctionConnection(4, 8),
                    new BuyerAuctionConnection(4, 10),
                }),
            new Buyer(5, "Чубрин", "Александр", "Андреевич", "8572", "547296", "г. Самара ул. Авроры 52 кв. 11",
                new List < BuyerAuctionConnection > {
                    new BuyerAuctionConnection(5, 2),
                    new BuyerAuctionConnection(5, 5),
                    new BuyerAuctionConnection(5, 7),
                    new BuyerAuctionConnection(5, 8),
                }),
            new Buyer(6, "Сомова", "Надежда", "Николаевна", "6356", "782546", "г. Новокуйбышевск ул. Карла Маркса 81 кв. 39",
                new List < BuyerAuctionConnection > {
                    new BuyerAuctionConnection(6, 4),
                    new BuyerAuctionConnection(6, 5),
                    new BuyerAuctionConnection(6, 7),
                    new BuyerAuctionConnection(6, 8),
                }),
            new Buyer(7, "Мочалов", "Андрей", "Сергеевич", "6567", "856456", "г. Сызрань ул. Подшипниковая 12 кв. 2",
                new List < BuyerAuctionConnection >
                {
                    new BuyerAuctionConnection(7, 3),
                    new BuyerAuctionConnection(7, 5),
                    new BuyerAuctionConnection(7, 7),
                    new BuyerAuctionConnection(7, 8),
                    new BuyerAuctionConnection(7, 9),
                }),
            new Buyer(8, "Аскерова", "Вера", "Игоревна", "7145", "624256", "г. Самара ул. Фадеева 1 кв. 54",
                new List < BuyerAuctionConnection >
                {
                    new BuyerAuctionConnection(8, 3),
                    new BuyerAuctionConnection(8, 5),
                    new BuyerAuctionConnection(8, 7),
                    new BuyerAuctionConnection(8, 8),
                    new BuyerAuctionConnection(8, 10),
                })
        };

        _buildings = new List<Building>{
            new Building(1, "Ул. Московскосе шоссе д. 22 кв. 8", 1, 43.9, 9, new DateTime(1980, 1, 10),
                new List<BuildingAuctionConnection>
                {
                    new BuildingAuctionConnection(1, 1)
                }),
            new Building(2, "Ул. Ново-вокзальная д. 1 кв. 19", 1, 63.0, 9, new DateTime(1988, 10, 21),
                new List<BuildingAuctionConnection>
                {
                    new BuildingAuctionConnection(2, 2)
                }),
            new Building(3, "Ул. Фадеева д. 62", 1, 1243.9, 2, new DateTime(1966, 6, 1),
                new List<BuildingAuctionConnection>
                {
                    new BuildingAuctionConnection(3, 3)
                }),
            new Building(4, "Ул. Стара-Загора д. 78 кв. 41", 1, 98.3, 12, new DateTime(1978, 6,13),
                new List < BuildingAuctionConnection >
                {
                    new BuildingAuctionConnection(4, 5)
                }),
            new Building(5, "Ул. Cолнечная д. 30", 1, 298.3, 12, new DateTime(2006, 3, 1),
                new List < BuildingAuctionConnection >
                {
                    new BuildingAuctionConnection(5, 4),
                    new BuildingAuctionConnection(5, 10),
                }),
            new Building(6, "Ул. Ставропольская д. 214 кв. 8", 2, 33.9, 16, new DateTime(2007,10,11),
                new List<BuildingAuctionConnection>{}),
            new Building(7, "Ул. Советская д. 119 кв. 1", 2, 43.0, 2, new DateTime(1941, 3, 3),
                new List < BuildingAuctionConnection >  
                {
                    new BuildingAuctionConnection(7, 5)
                }),
            new Building(8, "Ул. Мирная д. 165", 2, 283.9, 2, new DateTime(2003, 7, 13),
                new List < BuildingAuctionConnection >
                {
                    new BuildingAuctionConnection(8, 6),
                    new BuildingAuctionConnection(8, 8)
                }),
            new Building(9, "Ул. Черемшанская д. 158 кв. 41", 2, 112.3, 5, new DateTime(1973, 5, 30),
                new List < BuildingAuctionConnection >
                {
                    new BuildingAuctionConnection(9, 1),
                    new BuildingAuctionConnection(9, 7)
                }),
            new Building(10, "Ул. Юнных пионеров д. 154А", 2, 2482.3, 3, new DateTime(1969, 12, 30),
                new List < BuildingAuctionConnection >
                {
                    new BuildingAuctionConnection(10, 4),
                    new BuildingAuctionConnection(10, 9)
                })
        };

        _privatized = new List<Privatized>
        {
            new Privatized(1, 1, 1, new DateTime(2022, 3, 17), 615827.99, 1297618.13),
            new Privatized(2, 4, 2, new DateTime(2022, 3, 17), 862100.93, 1231971.10),
            new Privatized(3, 8, 3, new DateTime(2022, 3, 17), 1062109.00, 14301872.17),
            new Privatized(7, 2, 5, new DateTime(2022, 3, 17), 1846378.72, 2647635.37),
            new Privatized(8, 1, 8, new DateTime(2022, 3, 20), 628476.17, 964372.09),
            new Privatized(9, 8, 7, new DateTime(2022, 3, 19), 2657387.93, 4726478.00)
        };

        _auctions = new List<Auction>
        {
            new Auction(1, new DateTime(2022, 3, 17), 1,
                new List<BuildingAuctionConnection>{
                    new BuildingAuctionConnection(1, 1),
                    new BuildingAuctionConnection(9, 1)
                },
                new List<BuyerAuctionConnection>{
                    new BuyerAuctionConnection(1, 1),
                    new BuyerAuctionConnection(2, 1)
                }
            ),
            new Auction(2, new DateTime(2022, 3, 17), 3,
                new List<BuildingAuctionConnection>
                {
                    new BuildingAuctionConnection(2, 2)
                },
                new List<BuyerAuctionConnection>
                {
                    new BuyerAuctionConnection(4, 2),
                    new BuyerAuctionConnection(5, 2)
                }
            ),
            new Auction(3, new DateTime(2022, 3, 17), 7,
                new List<BuildingAuctionConnection>
                {
                    new BuildingAuctionConnection(3, 3)
                },
                new List<BuyerAuctionConnection>
                {
                    new BuyerAuctionConnection(8, 3),
                    new BuyerAuctionConnection(7, 3)
                }
            ),
            new Auction(4, new DateTime(2022, 3, 17), 8,
                new List<BuildingAuctionConnection>
                {
                    new BuildingAuctionConnection(5, 4),
                    new BuildingAuctionConnection(10, 4)
                },
                new List<BuyerAuctionConnection>
                {
                    new BuyerAuctionConnection(3, 4),
                    new BuyerAuctionConnection(6, 4)
                }
            ),
            new Auction(5, new DateTime(2022, 3, 17), 4,
                new List < BuildingAuctionConnection >
                {
                    new BuildingAuctionConnection(4, 5),
                    new BuildingAuctionConnection(7, 5)
                },
                new List < BuyerAuctionConnection >
                {
                    new BuyerAuctionConnection(1, 5),
                    new BuyerAuctionConnection(2, 5),
                    new BuyerAuctionConnection(3, 5),
                    new BuyerAuctionConnection(4, 5),
                    new BuyerAuctionConnection(5, 5),
                    new BuyerAuctionConnection(6, 5),
                    new BuyerAuctionConnection(7, 5),
                    new BuyerAuctionConnection(8, 5)
                }),
            new Auction(6, new DateTime(2022, 3, 17), 2,
                new List < BuildingAuctionConnection >
                {
                    new BuildingAuctionConnection(8, 6)
                },
                new List < BuyerAuctionConnection >
                {
                    new BuyerAuctionConnection(1, 6),
                    new BuyerAuctionConnection(2, 6)
                }),
            new Auction(7, new DateTime(2022, 3, 19), 1,
                new List < BuildingAuctionConnection >
                {
                    new BuildingAuctionConnection(9, 7)
                },
                new List < BuyerAuctionConnection >
                {
                    new BuyerAuctionConnection(1, 7),
                    new BuyerAuctionConnection(2, 7),
                    new BuyerAuctionConnection(3, 7),
                    new BuyerAuctionConnection(4, 7),
                    new BuyerAuctionConnection(5, 7),
                    new BuyerAuctionConnection(6, 7),
                    new BuyerAuctionConnection(7, 7),
                    new BuyerAuctionConnection(8, 7)
                }),
            new Auction(8, new DateTime(2022, 3, 20), 7,
                new List < BuildingAuctionConnection >
                {
                    new BuildingAuctionConnection(8, 8)
                },
                new List < BuyerAuctionConnection >
                {
                    new BuyerAuctionConnection(1, 8),
                    new BuyerAuctionConnection(2, 8),
                    new BuyerAuctionConnection(3, 8),
                    new BuyerAuctionConnection(4, 8),
                    new BuyerAuctionConnection(5, 8),
                    new BuyerAuctionConnection(6, 8),
                    new BuyerAuctionConnection(7, 8),
                    new BuyerAuctionConnection(8, 8)
                }),
            new Auction(9, new DateTime(2022, 3, 21), 2,
                new List < BuildingAuctionConnection >
                {
                    new BuildingAuctionConnection(10, 9)
                },
                new List < BuyerAuctionConnection >
                {
                    new BuyerAuctionConnection(7, 9),
                    new BuyerAuctionConnection(3, 9)
                }),
            new Auction(10, new DateTime(2022, 3, 21), 3,
                new List < BuildingAuctionConnection >
                {
                    new BuildingAuctionConnection(5, 10)
                },
                new List < BuyerAuctionConnection >
                {
                    new BuyerAuctionConnection(8, 10),
                    new BuyerAuctionConnection(4, 10),
                    new BuyerAuctionConnection(1, 10)
                })
        };
    }

    /// <summary>
    /// Gets a list of districts associated with the non-residential fund.
    /// </summary>
    public List<District> Districts => _districts;

    /// <summary>
    /// Gets a list of organizations involved with the non-residential fund.
    /// </summary>
    public List<Organization> Organizations => _organizations;

    /// <summary>
    /// Gets a list of buyers participating in auctions within the fund.
    /// </summary>
    public List<Buyer> Buyers => _buyers;

    /// <summary>
    /// Gets a list of buildings associated with the non-residential fund.
    /// </summary>
    public List<Building> Buildings => _buildings;
    /// <summary>
    /// Gets a list of privatized entities within the fund.
    /// </summary>
    public List<Privatized> Privatized => _privatized;

    /// <summary>
    /// Gets a list of all auctions related to the non-residential fund.
    /// </summary>
    public List<Auction> Auctions => _auctions;
}