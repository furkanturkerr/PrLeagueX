using AutoMapper;
using PrLeagueX.DtoLayer.LeagueDtos;
using PrLeagueX.DtoLayer.MatchDtos;
using PrLeagueX.DtoLayer.SeasonDtos;
using PrLeagueX.DtoLayer.StadiumDtos;
using PrLeagueX.DtoLayer.TeamDtos;
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.BusinessLayer.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Match, ResultMatchDto>()
            .ReverseMap();

        CreateMap<Season, ResultSeasonDto>().ReverseMap();
        CreateMap<Season, CreateSeasonDto>().ReverseMap();
        CreateMap<Season, UpdateSeasonDto>().ReverseMap();
        
        CreateMap<League, ResultLeagueDto>().ReverseMap();
        
        CreateMap<Match, ResultFixtureDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status))
            .ForMember(dest => dest.HomeTeamName, opt => opt.MapFrom(src => src.HomeTeam.TeamName))
            .ForMember(dest => dest.HomeTeamShortName, opt => opt.MapFrom(src => src.HomeTeam.ShortName))
            .ForMember(dest => dest.HomeTeamLogoUrl, opt => opt.MapFrom(src => src.HomeTeam.LogoUrl))
            .ForMember(dest => dest.AwayTeamName, opt => opt.MapFrom(src => src.AwayTeam.TeamName))
            .ForMember(dest => dest.AwayTeamShortName, opt => opt.MapFrom(src => src.AwayTeam.ShortName))
            .ForMember(dest => dest.AwayTeamLogoUrl, opt => opt.MapFrom(src => src.AwayTeam.LogoUrl))
            .ReverseMap();

        CreateMap<Match, ResultMatchDto>()
            .ForMember(x => x.HomeTeamName, opt => opt.MapFrom(src => src.HomeTeam.TeamName))
            .ForMember(x => x.AwayTeamName, opt => opt.MapFrom(src => src.AwayTeam.TeamName))
            .ForMember(x => x.StadiumName, opt => opt.MapFrom(src => src.HomeTeam.Stadium.StadiumName))
            .ReverseMap();
        
        CreateMap<Match, ResultMatchCardDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (int)src.Status))
            .ForMember(dest => dest.HomeTeamName, opt => opt.MapFrom(src => src.HomeTeam.TeamName))
            .ForMember(dest => dest.HomeTeamShortName, opt => opt.MapFrom(src => src.HomeTeam.ShortName))
            .ForMember(dest => dest.HomeTeamLogoUrl, opt => opt.MapFrom(src => src.HomeTeam.LogoUrl))
            .ForMember(dest => dest.AwayTeamName, opt => opt.MapFrom(src => src.AwayTeam.TeamName))
            .ForMember(dest => dest.AwayTeamShortName, opt => opt.MapFrom(src => src.AwayTeam.ShortName))
            .ForMember(dest => dest.AwayTeamLogoUrl, opt => opt.MapFrom(src => src.AwayTeam.LogoUrl))
            .ReverseMap();


        CreateMap<Team, ResultTeamDto>()
            .ForMember(dest => dest.StadiumName, opt => opt.MapFrom(src => src.Stadium.StadiumName))
            .ReverseMap();
        CreateMap<Team, CreateTeamDto>().ReverseMap();
        CreateMap<Team, UpdateTeamDto>().ReverseMap();

        CreateMap<Stadium, ResultStadiumDto>().ReverseMap();
        CreateMap<Stadium, CreateStadiumDto>().ReverseMap();
        CreateMap<Stadium, UpdateStadiumDto>().ReverseMap();
    }
}