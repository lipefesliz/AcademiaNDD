namespace SalaReuniao.Base
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public abstract void Validate();

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Entity entity = obj as Entity;
            if (entity == null)
                return false;
            else
                return Id.Equals(entity.Id);
        }
    }
}
