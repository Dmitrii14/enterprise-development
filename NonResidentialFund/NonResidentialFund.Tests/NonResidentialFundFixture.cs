using NonResidentialFund.Domain;

namespace NonResidentialFund.Tests;
public class NonResidentialFundFixture
{

    public List<Buyer> FixtureBuyers =>
    [
        new(1, "Мизягин", "Евгений", "Викторович", "3716", "928715", "г. Самара ул. Московское шоссе 252 кв. 186",
            [
                new BuyerAuctionConnection(1, 1),
                new BuyerAuctionConnection(1, 5),
                new BuyerAuctionConnection(1, 6),
                new BuyerAuctionConnection(1, 7),
                new BuyerAuctionConnection(1, 8),
                new BuyerAuctionConnection(1, 10)
            ]),
        new(2, "Грачев", "Михаил", "Александрович", "6251", "629574", "г. Сызрань ул. Советская 15 кв. 3",
            [
                new BuyerAuctionConnection(2, 1),
                new BuyerAuctionConnection(2, 5),
                new BuyerAuctionConnection(2, 6),
                new BuyerAuctionConnection(2, 7),
                new BuyerAuctionConnection(2, 8)
            ]),
        new(3, "Подлипаев", "Олег", "Викторович", "6295", "746153", "г. Новокуйбышевск ул. Советская 71 кв. 13",
            [
                new BuyerAuctionConnection(3, 4),
                new BuyerAuctionConnection(3, 5),
                new BuyerAuctionConnection(3, 7),
                new BuyerAuctionConnection(3, 8),
                new BuyerAuctionConnection(3, 9),
            ]),
        new(4, "Корнеев", "Николай", "Игоревич", "9462", "745625", "г. Самара ул. Ново-садовая 25 кв. 77",
            [
                new BuyerAuctionConnection(4, 2),
                new BuyerAuctionConnection(4, 5),
                new BuyerAuctionConnection(4, 7),
                new BuyerAuctionConnection(4, 8),
                new BuyerAuctionConnection(4, 10),
            ]),
        new(5, "Чубрин", "Александр", "Андреевич", "8572", "547296", "г. Самара ул. Авроры 52 кв. 11",
            [
                new BuyerAuctionConnection(5, 2),
                new BuyerAuctionConnection(5, 5),
                new BuyerAuctionConnection(5, 7),
                new BuyerAuctionConnection(5, 8),
            ]),
        new(6, "Сомова", "Надежда", "Николаевна", "6356", "782546", "г. Новокуйбышевск ул. Карла Маркса 81 кв. 39",
            [
                new BuyerAuctionConnection(6, 4),
                new BuyerAuctionConnection(6, 5),
                new BuyerAuctionConnection(6, 7),
                new BuyerAuctionConnection(6, 8),
            ]),
        new(7, "Мочалов", "Андрей", "Сергеевич", "6567", "856456", "г. Сызрань ул. Подшипниковая 12 кв. 2",
            [
                new BuyerAuctionConnection(7, 3),
                new BuyerAuctionConnection(7, 5),
                new BuyerAuctionConnection(7, 7),
                new BuyerAuctionConnection(7, 8),
                new BuyerAuctionConnection(7, 9),
            ]),
        new(8, "Аскерова", "Вера", "Игоревна", "7145", "624256", "г. Самара ул. Фадеева 1 кв. 54",
            [
                new BuyerAuctionConnection(8, 3),
                new BuyerAuctionConnection(8, 5),
                new BuyerAuctionConnection(8, 7),
                new BuyerAuctionConnection(8, 8),
                new BuyerAuctionConnection(8, 10),
            ])   
    ];

    public List<Building> FixtureBuildings =>
    [
        new(1, "Ул. Московскосе шоссе д. 22 кв. 8", 1, 43.9, 9, new(1980, 1, 10),
            [
                new BuildingAuctionConnection(1, 1)
            ]),
        new(2, "Ул. Ново-вокзальная д. 1 кв. 19", 1, 63.0, 9, new(1988, 10, 21),
            [
                new BuildingAuctionConnection(2, 2)
            ]),
        new(3, "Ул. Фадеева д. 62", 1, 1243.9, 2, new(1966, 6, 1),
            [
                new BuildingAuctionConnection(3, 3)
            ]),
        new(4, "Ул. Стара-Загора д. 78 кв. 41", 1, 98.3, 12, new(1978, 6,13),
            [
                new BuildingAuctionConnection(4, 5)
            ]),
        new(5, "Ул. Cолнечная д. 30", 1, 298.3, 12, new(2006, 3, 1),
            [
                new BuildingAuctionConnection(5, 4),
                new BuildingAuctionConnection(5, 10),
            ]),
        new(6, "Ул. Ставропольская д. 214 кв. 8", 2, 33.9, 16, new(2007,10,11),[]),
        new(7, "Ул. Советская д. 119 кв. 1", 2, 43.0, 2, new(1941, 3, 3),
            [
                new BuildingAuctionConnection(7, 5)
            ]),
        new(8, "Ул. Мирная д. 165", 2, 283.9, 2, new(2003, 7, 13),
            [
                new BuildingAuctionConnection(8, 6),
                new BuildingAuctionConnection(8, 8)
            ]),
        new(9, "Ул. Черемшанская д. 158 кв. 41", 2, 112.3, 5, new(1973, 5, 30),
            [
                new BuildingAuctionConnection(9, 1),
                new BuildingAuctionConnection(9, 7)
            ]),
        new(10, "Ул. Юнных пионеров д. 154А", 2, 2482.3, 3, new(1969, 12, 30),
            [
                new BuildingAuctionConnection(10, 4),
                new BuildingAuctionConnection(10, 9)
            ])
    ];

    public List<Privatized> FixturePrivatized =>
    [       
        new(1, 1, 1, new DateOnly(2022, 3, 17), 615827.99, 1297618.13),
        new(2, 4, 2, new DateOnly(2022, 3, 17), 862100.93, 1231971.10),
        new(3, 8, 3, new DateOnly(2022, 3, 17), 1062109.00, 14301872.17),
        new(7, 2, 5, new DateOnly(2022, 3, 17), 1846378.72, 2647635.37),
        new(8, 1, 8, new DateOnly(2022, 3, 20), 628476.17, 964372.09),
        new(9, 8, 7, new DateOnly(2022, 3, 19), 2657387.93, 4726478.00)
    ];

    public List<Auction> FixtureAuctions => 
    [
        new(1, new DateOnly(2022, 3, 17), 1,
            [ new BuildingAuctionConnection(1, 1), 
                new BuildingAuctionConnection(9, 1) ],
            [ new BuyerAuctionConnection(1, 1), 
                new BuyerAuctionConnection(2, 1) ]
        ),
        new(2, new DateOnly(2022, 3, 17), 3,
            [ new BuildingAuctionConnection(2, 2) ],
            [ new BuyerAuctionConnection(4, 2), new BuyerAuctionConnection(5, 2) ]
        ),
        new(3, new DateOnly(2022, 3, 17), 7,
            [ new BuildingAuctionConnection(3, 3) ],
            [ new BuyerAuctionConnection(8, 3), new BuyerAuctionConnection(7, 3) ]
        ),
        new(4, new DateOnly(2022, 3, 17), 8,
            [ new BuildingAuctionConnection(5, 4), 
                new BuildingAuctionConnection(10, 4) ],
            [ new BuyerAuctionConnection(3, 4), 
                new BuyerAuctionConnection(6, 4) ]
        ),
        new(5, new DateOnly(2022, 3, 17), 4,
            [ new BuildingAuctionConnection(4, 5), new BuildingAuctionConnection(7, 5) ],
            [ new BuyerAuctionConnection(1, 5),
                new BuyerAuctionConnection(2, 5), 
                new BuyerAuctionConnection(3, 5), 
                new BuyerAuctionConnection(4, 5),
                new BuyerAuctionConnection(5, 5), 
                new BuyerAuctionConnection(6, 5), 
                new BuyerAuctionConnection(7, 5), 
                new BuyerAuctionConnection(8, 5) ]
        ),
        new(6, new DateOnly(2022, 3, 17), 2,
            [ new BuildingAuctionConnection(8, 6) ],
            [ new BuyerAuctionConnection(1, 6), 
                new BuyerAuctionConnection(2, 6) ]
        ),
        new(7, new DateOnly(2022, 3, 19), 1,
            [ new BuildingAuctionConnection(9, 7) ],
            [ new BuyerAuctionConnection(1, 7),
                new BuyerAuctionConnection(2, 7), 
                new BuyerAuctionConnection(3, 7), 
                new BuyerAuctionConnection(4, 7),
                new BuyerAuctionConnection(5, 7), 
                new BuyerAuctionConnection(6, 7), 
                new BuyerAuctionConnection(7, 7), 
                new BuyerAuctionConnection(8, 7) ]
        ),
        new(8, new DateOnly(2022, 3, 20), 7,
            [ new BuildingAuctionConnection(8, 8) ],
            [ new BuyerAuctionConnection(1, 8), 
                new BuyerAuctionConnection(2, 8), 
                new BuyerAuctionConnection(3, 8), 
                new BuyerAuctionConnection(4, 8),
                new BuyerAuctionConnection(5, 8), 
                new BuyerAuctionConnection(6, 8), 
                new BuyerAuctionConnection(7, 8), 
                new BuyerAuctionConnection(8, 8) ]
        ),
        new(9, new DateOnly(2022, 3, 21), 2,
            [ new BuildingAuctionConnection(10, 9) ],
            [ new BuyerAuctionConnection(7, 9), new BuyerAuctionConnection(3, 9) ]
        ),
        new(10, new DateOnly(2022, 3, 21), 3,
            [ new BuildingAuctionConnection(5, 10) ],
            [ new BuyerAuctionConnection(8, 10), 
                new BuyerAuctionConnection(4, 10), 
                new BuyerAuctionConnection(1, 10) ]
        )
    ];
}