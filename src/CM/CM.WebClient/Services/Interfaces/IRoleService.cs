using CM.SharedWithClient;

namespace CM.WebClient.Services.Interfaces;

public interface IRoleService
{
    public Task<PersonDataViewModel> PromoteAsMember(string personId);
    public Task<PersonDataViewModel> RemoveAsMember(string personId);
    public Task<PersonDataViewModel> PromoteAsCouch(string personId);
    public Task<PersonDataViewModel> RemoveAsCouch(string personId);
    public Task<PersonDataViewModel> PromoteAsHR(string personId);
    public Task<PersonDataViewModel> RemoveAsHR(string personId);

}