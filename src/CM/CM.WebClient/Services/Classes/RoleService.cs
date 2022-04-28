using CM.SharedWithClient;
using CM.SharedWithClient.RequestViewModels;
using CM.WebClient.Services.Interfaces;


namespace CM.WebClient.Services.Classes;

public class RoleService : IRoleService
{
    private IHttpService _httpService { get; set; }

    public RoleService(IHttpService httpService)
    {
        this._httpService = httpService;

    }

    public async Task<PersonDataViewModel> PromoteAsMember(string personId)
    {
        AddRoleToPersonRequestDataViewModel addRoleToPersonRequestDataviewModel =
            new AddRoleToPersonRequestDataViewModel() {PersonId = personId};
        return await _httpService.Post<PersonDataViewModel>("Role/AddMemberRole", addRoleToPersonRequestDataviewModel);
    }

    public async Task<PersonDataViewModel> RemoveAsMember(string personId)
    {
        return await _httpService.Delete<PersonDataViewModel>("Role/DeleteMemberRole?personId=" + personId);
    }

    public async Task<PersonDataViewModel> PromoteAsCouch(string personId)
    {
        AddRoleToPersonRequestDataViewModel addRoleToPersonRequestDataviewModel =
            new AddRoleToPersonRequestDataViewModel() {PersonId = personId};
        return await _httpService.Post<PersonDataViewModel>("Role/AddCouchRole", addRoleToPersonRequestDataviewModel);
    }


public async Task<PersonDataViewModel> RemoveAsCouch(string personId)
    {
        return  await _httpService.Delete<PersonDataViewModel>("Role/DeleteCouchRole?personId="+ personId);
    }

    public async Task<PersonDataViewModel> PromoteAsHR(string personId)
    {
        AddRoleToPersonRequestDataViewModel addRoleToPersonRequestDataviewModel =
            new AddRoleToPersonRequestDataViewModel() { PersonId = personId};
        return  await _httpService.Post<PersonDataViewModel>("Role/AddHRRole", addRoleToPersonRequestDataviewModel);
        
    }
    
    public async Task<PersonDataViewModel> RemoveAsHR(string personId)
    {
        return  await _httpService.Delete<PersonDataViewModel>("Role/DeleteHRRole?personId="+ personId);
    }
}