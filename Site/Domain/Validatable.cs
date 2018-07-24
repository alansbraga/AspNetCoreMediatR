using Flunt.Notifications;
using Flunt.Validations;

namespace Site.Domain
{
    public abstract class Validatable : Notifiable, IValidatable
    {
        public abstract void Validate();
    }
}
