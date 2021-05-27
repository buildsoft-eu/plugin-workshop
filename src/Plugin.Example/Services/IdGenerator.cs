namespace Plugin.Example.Services
{
    public class IdGenerator
    {
        private int _nextAnBarId = 1;
        private int _nextAnPointId = 1;
        private int _nextBarGroupId = 1;
        private int _nextPhysicalBarId = 1;

        public int CreateNewAnalysisBarId()
        {
            return _nextAnBarId++;
        }

        public int CreateNewAnalysisPointId()
        {
            return _nextAnPointId++;
        }

        public int CreateNewBarGroupId()
        {
            return _nextBarGroupId++;
        }

        public int CreateNewPhysicalBarId()
        {
            return _nextPhysicalBarId++;
        }
    }
}
