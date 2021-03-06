#Task 4: Microsoft Unity Lifetime management

## Life time managers

* Lifetime managers define the lifetime of created object instances.
* Most important lifetime managers are:
  * ```TransientLifetimeManager```
	  * The default lifetime manager.
	  * An instance of class is created per-resolution.
	  * Object lifetime is not managed by the unity container.
  * ```ContainerControlledLifetimeManager```
     * Ensures that there will be only single instance of the object which 
       lifetime will be managed by unity container.
     * If the class implements ```IDisposable``` interface the instance will be 
       disposed upon container disposal.
     * If any child container will be created and the dependency will not 
       be re-registered the parent instance will be resolved.
	 * This is per-container Singleton
	 * If the class holds state, it would be shared by all dependent 
           components. 
	 * Implementation may need to be synchronized for multithreading.
  * ```ExternallyControlledLifetimeManager```
     * To be used when you register any object instance into unity container 
       which lifetime should not be managed by unity container.
     * A typical example is a legacy singleton implementation being registered 
       as instance into unity container.
* Lifetime manager can be optionally specified when you are registering the 
  dependency either for a type or for an instance.

## How to start?

1. The project is currently using constructor injection.
2. Get familiar with project 040_UnityLifetimeManagement.
3. Find the ```FileResultWriter``` class:
   * Implementation is using a statically defined output file.
   * If you will open the same file multiple times you may expect an exception 
     to be thrown.
   * This implies that the class instance is a candidate to become 
     per-application (global) singleton so it must be properly registered in 
     the unity container.
4. Find the ```Bootstrapper``` class.
5. Properly adjust its ```SetupContainer()```  and ```SetupChildContainer()```
   methods using lifetime managers as appropriate.

## Extras

* Feel free to modify the solution by providing new implementations of interface
  IOperation, e.g. Minus.
* Try implement alternative ```IResultWriter``` which will write result to 
  a file specified during registration to Microsoft Unity.

## Sample solution

* This can be as simple as adding ```new ContainerControlledLifetimeManager()``` into ```Bootstrapper.SetupChildContainer()```.
* Think about the consequences whether you will or will not move the registration into ```Bootstrapper.SetupContainer()``` method.
  * The point simply now is that the ```FileResultWriter``` is ```IDisposable```.
  * Since its lifetime is now managed by the child container (```ContainerControllerLifetimeManager```) it is disposed as a part of child container disposal.
  * If the lifetime of child containers overlaps you have to push the registration into the root container to avoid file access conflicts.

* For more info about the sample solution please see IoCTaskSolutions, project 
  040_UnityLifetimeManagement.
* Read the comments throughout the code carefully, they contain important 
  information in regards inversion of control and dependency injection.

