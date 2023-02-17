using Modules.DataBase;

namespace Modules.Core.Initializing.Subtasks
{
    public class LoadDataBaseTask : Subtask
    {
        public override int Weight => _weight;
        private int _weight;

        private DataBaseManager _manager;


        public LoadDataBaseTask(DataBaseManager manager, int weight = 10)
        {
            _manager = manager;
            _weight = weight;
        }


        public override void Run()
        {
            if (_manager != null)
                _manager.Init(Complete, Fail);
            else
                Fail(999);  //TODO: error code
        }
    }
}
