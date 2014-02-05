using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularTutorial.Entities;
using Microsoft.WindowsAzure.Storage.Table;

namespace AngularTutorial.Repository
{
    public interface IInstructionRepository : ITableStorageRepositoryBase<Instruction>
    {
        
    }

    public class InstructionRepository : TableStorageRepositoryBase<Instruction>, IInstructionRepository
    {
        public InstructionRepository(IUnitOfWork unitOfWork)
            :base(unitOfWork.InstructionTable)
        {
        }
    }
}
