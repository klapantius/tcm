using System;

using Microsoft.TeamFoundation.Client;


namespace TestControllerManager.BusinessLogic
{
    public class TfsTeamProjectCollectionWrapper : ITfsTeamProjectCollection
    {
        private readonly TfsTeamProjectCollection myTfsTeamProjectCollection;

        public TfsTeamProjectCollectionWrapper(Uri uri)
        {
            myTfsTeamProjectCollection = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(uri);
        }
        public T GetService<T>()
        {
            return myTfsTeamProjectCollection.GetService<T>();
        }
    }
}
