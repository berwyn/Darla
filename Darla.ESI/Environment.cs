namespace Darla.ESI
{
    public enum Environment
    {
        Legacy,
        Latest,
        Dev,
    }

    public static class EnvironmentExtensions
    {
        public static string ToURLSegment(this Environment environment)
        {
            switch (environment)
            {
                case Environment.Legacy:
                    return "legacy";
                default:
                case Environment.Latest:
                    return "latest";
                case Environment.Dev:
                    return "dev";
            }
        }
    }

    public enum Source
    {
        Tranquility,
        Singularity,
    }

    public static class SourceExtensions
    {
        public static string ToURLSegment(this Source source)
        {
            switch (source)
            {
                default:
                case Source.Tranquility:
                    return "tranquility";
                case Source.Singularity:
                    return "singularity";
            }
        }
    }
}
