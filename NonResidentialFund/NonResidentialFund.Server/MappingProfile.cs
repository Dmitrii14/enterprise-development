using AutoMapper;
using NonResidentialFund.Domain;
using NonResidentialFund.Server.Dto;

namespace NonResidentialFund.Server;

/// <summary>
/// Mapping profile for configuring AutoMapper mappings.
/// </summary>
public class MappingProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MappingProfile"/> class.
    /// </summary>
    public MappingProfile()
    {
        CreateMap<Auction, AuctionGetDto>();
        CreateMap<AuctionPostDto, Auction>();

        CreateMap<Building, BuildingGetDto>();
        CreateMap<BuildingPostDto, Building>();

        CreateMap<BuildingAuctionConnection, BuildingAuctionConnectionForAuctionDto>().ReverseMap();
        CreateMap<BuildingAuctionConnection, BuildingAuctionConnectionForBuildingDto>().ReverseMap();

        CreateMap<Buyer, BuyerAddressDto>();
        CreateMap<Buyer, BuyerGetDto>();
        CreateMap<BuyerPostDto, Buyer>();

        CreateMap<BuyerAuctionConnection, BuyerAuctionConnectionForAuctionDto>().ReverseMap();
        CreateMap<BuyerAuctionConnection, BuyerAuctionConnectionForBuyerDto>().ReverseMap();

        CreateMap<District, DistrictGetDto>();
        CreateMap<DistrictPostDto, District>();

        CreateMap<Organization, OrganizationGetDto>();
        CreateMap<OrganizationPostDto, Organization>();

        CreateMap<Privatized, PrivatizedGetDto>();
        CreateMap<PrivatizedPostDto, Privatized>();
    }
}