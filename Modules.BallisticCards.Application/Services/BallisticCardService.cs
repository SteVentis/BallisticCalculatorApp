using AutoMapper;
using Modules.BallisticCards.Application.Abstractions;
using Modules.BallisticCards.Domain.Dtos;
using Modules.BallisticCards.Domain.Models;
using Modules.BallisticCards.Domain.Repositories.Interfaces;
using OfficeOpenXml;

namespace Modules.BallisticCards.Application.Services;

public sealed class BallisticCardService : IBallisticCardService
{
    private readonly IBallisticCardRepository _ballisticCardRepo;
    private readonly IMemoryCachingService _memoryCachingService;
    private readonly IMapper _mapper;
    private readonly IExcelService _excelService;
    public BallisticCardService(
        IBallisticCardRepository ballisticCardRepo, 
        IMemoryCachingService memoryCachingService, 
        IMapper mapper, 
        IExcelService excelService)
    {
        _ballisticCardRepo = ballisticCardRepo;
        _memoryCachingService = memoryCachingService;
        _mapper = mapper;
        _excelService = excelService;
    }


    public async Task DeleteBallisticCard(long id)
    {
       await _ballisticCardRepo.DeleteBallisticCard(id);
        
        _memoryCachingService.DeleteBallisticCardInMemory(id);
    }

    public async Task<BallisticCardDto> GetBallisticCardById(long id)
    {
        BallisticCardDto ballisticCardDto = _memoryCachingService.GetBallisticCardFromMemory(id);

        if (ballisticCardDto is null)
        {
            BallisticCard ballisticCard = await _ballisticCardRepo.GetBallisticCardById(id);

            ballisticCardDto = _mapper.Map<BallisticCardDto>(ballisticCard);
        }

        return ballisticCardDto;
    }

    public async Task<List<BallisticCardDto>> GetUsersAllBallisticCards(string usersId)
    {
        List<BallisticCard> ballisticCards =  await _ballisticCardRepo.GetUsersAllBallisticCards(usersId);

        List<BallisticCardDto> ballisticCardsConvertedToDtos = _mapper.Map<List<BallisticCardDto>>(ballisticCards);

        foreach (BallisticCardDto ballisticCardDto in ballisticCardsConvertedToDtos)
        {
            _memoryCachingService.InsertBallisticCardInMemory(ballisticCardDto);
        }

        return ballisticCardsConvertedToDtos;
    }

    public async Task InsertBallisticCard(BallisticCardDto ballisticCard)
    {
        var ballisticCardToBeInsertedInRepo = _mapper.Map<BallisticCard>(ballisticCard);

        await _ballisticCardRepo.InsertBallisticCard(ballisticCardToBeInsertedInRepo);

        _memoryCachingService.InsertBallisticCardInMemory(ballisticCard);
    }

    public ExcelFile ExportBallisticCardToExcel(long id)
    {
        BallisticCardDto ballisticCardDto = _memoryCachingService.GetBallisticCardFromMemory(id);

        ExcelFile worksheet = _excelService.ExportBallisticCardToExcel(ballisticCardDto);

        return worksheet;
    }
}
