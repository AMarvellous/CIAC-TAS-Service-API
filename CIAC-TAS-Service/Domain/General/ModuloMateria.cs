namespace CIAC_TAS_Service.Domain.General
{
    public class ModuloMateria
    {
        public int ModuloId { get; set; }
        public Modulo Modulo { get; set; }
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
    }
}
