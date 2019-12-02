# RunPathTestApi
Web Api Json Streaming

Returning all Albums merged with photos:
https://localhost:44381/api/photoAlbums

Returning all Albums merged with photos by user ID:
https://localhost:44381/api/photoAlbums/5

# Important points
Web Api 2.0 Core dot net.

It uses Solid Principles for TDD dev Approach.

The service layer uses struct for the data model to reduce the effort of the GC. Moving to Core.Net 3, it is possible to convert the struct to ref struct and replace string types to Char[]. So most of the data will be stored in the stack, reducing the effort of GC.

For filtering Albums by any property belonging to Album or Photo, the service expects a predicate, so any filtering the can be used using simple lambdas expressions such as ”a=>a.id==id”.
Task<IEnumerable<Album>> AlbumsAsyn(Func<Album, bool> predicate)

Web Api returns async task<IEnumarable<T>>. It gives scalability as it can take advantage of using the thread pool.
A Mapper class was developed to take advantage of yield return. So it creates a stream, saving sever memory.






