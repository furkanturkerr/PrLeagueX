using AutoMapper;
using PrLeagueX.DtoLayer.MatchDtos;
using PrLeagueX.DtoLayer.SeasonDtos;
using PrLeagueX.Entity.Entities;

namespace PrLeagueX.BusinessLayer.Mapping;

public class GeneralMapping : Profile
{
    public GeneralMapping()
    {
        CreateMap<Match, ResultMatchDto>()
            .ReverseMap();

        CreateMap<Season, ResultSeasonDto>().ReverseMap();
    }
}