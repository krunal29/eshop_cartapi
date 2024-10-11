using eshop_cartapi.Business.Enums.General;

namespace eshop_cartapi.Business.ViewModels.General
{
    public class RoleAccessModel
    {
        public RoleAccessModel(ModuleEnum module, AccessTypeEnum accessType)
        {
            Module = module;
            AccessType = accessType;
        }

        public ModuleEnum Module { get; set; }

        public AccessTypeEnum AccessType { get; set; }
    }
}