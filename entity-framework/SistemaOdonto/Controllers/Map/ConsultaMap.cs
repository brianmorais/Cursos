using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Controllers.Map
{
    class ConsultaMap : EntityTypeConfiguration<Consulta>
    {
        public ConsultaMap()
        {
            this.ToTable("Consulta");
            this.HasKey(c => c.IdConsulta);
            this.Property(c => c.IdConsulta).HasColumnName("ID_CONSULTA");
            this.Property(c => c.IdDentista).HasColumnName("ID_DENTISTA");
            this.Property(c => c.IdPaciente).HasColumnName("ID_PACIENTE");
            this.Property(c => c.Data).HasColumnName("DATA_CONSULTA");
            this.Property(c => c.HoraMarcada).HasColumnName("HORAMARCADA_CONSULTA");
            this.Property(c => c.HoraInicio).HasColumnName("HORA_INICIO");
            this.Property(c => c.HoraFim).HasColumnName("HORAFIM_CONSULTA");
            this.Property(c => c.Observacoes).HasColumnName("OBSERVACOES_CONSULTA");
            this.Property(c => c.Status).HasColumnName("STATUS_CONSULTA");
        }
    }
}
