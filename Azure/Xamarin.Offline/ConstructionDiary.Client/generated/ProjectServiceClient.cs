// <auto-generated />
[assembly: Codeworx.Rest.RestProxy(typeof(global::ConstructionDiary.Contract.IProjectService), typeof(ConstructionDiary.Client.Generated.ProjectServiceClient))]
namespace ConstructionDiary.Client.Generated
{
    public class ProjectServiceClient : Codeworx.Rest.Client.RestClient<global::ConstructionDiary.Contract.IProjectService>, global::ConstructionDiary.Contract.IProjectService
    {
        public ProjectServiceClient(Codeworx.Rest.Client.RestOptions<global::ConstructionDiary.Contract.IProjectService> options): base(options)
        {
        }

        public global::System.Threading.Tasks.Task<global::ConstructionDiary.Model.ProjectInfo> GetProjectByNameAsync(string name)
        {
            return CallAsync(c => c.GetProjectByNameAsync(name));
        }

        public global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::ConstructionDiary.Model.ProjectInfo>> GetProjectsAsync()
        {
            return CallAsync(c => c.GetProjectsAsync());
        }
    }
}