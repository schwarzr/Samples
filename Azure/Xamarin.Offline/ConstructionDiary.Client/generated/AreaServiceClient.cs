// <auto-generated />
[assembly: Codeworx.Rest.RestProxy(typeof(global::ConstructionDiary.Contract.IAreaService), typeof(ConstructionDiary.Client.Generated.AreaServiceClient))]
namespace ConstructionDiary.Client.Generated
{
    public class AreaServiceClient : Codeworx.Rest.Client.RestClient<global::ConstructionDiary.Contract.IAreaService>, global::ConstructionDiary.Contract.IAreaService
    {
        public AreaServiceClient(Codeworx.Rest.Client.RestOptions<global::ConstructionDiary.Contract.IAreaService> options): base(options)
        {
        }

        public global::System.Threading.Tasks.Task<global::System.Collections.Generic.IEnumerable<global::ConstructionDiary.Model.AreaInfo>> GetAreaInfosAsync(global::System.Guid projectId)
        {
            return CallAsync(c => c.GetAreaInfosAsync(projectId));
        }
    }
}