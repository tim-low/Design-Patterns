# Design Patterns

Implemented in C#.

I wanted to practice some design patterns by creating my own examples. :smile:

## Pattern List

### Creational Patterns
- [Abstract Factory](/Design-Patterns/Creational/AbstractFactory.cs) (food shops)
- [Factory Method](/Design-Patterns/Creational/FactoryMethod.cs) (company departments)
- [Singleton](/Design-Patterns/Creational/Singleton.cs) (me and you)
- [Builder](/Design-Patterns/Creational/Builder.cs) (burger)

### Structural Patterns
- Facade
- Adapter
- Decorator
- Composite
- Proxy

### Behavioral Patterns
- Observer
- Strategy
- Command
- Iterator
- Template Method
- State

## Notes

### Abstract Factory & Factory Method
- SRP: Everything to do with creation is in one place.
- OCP: New products can be introduced to the program easily as long as they implement the Product interface.
- Loose coupling between factory and concrete products.

Abstract Factory | Factory Method
--- | ---
Used to create families of related products | Used to create 1 product only
Uses composition | Uses inheritance
Implemented using a set of factory methods | -
Used when the client doesn't care what classes are created runtime, as long as they get the job done (e.g. databases) | Used to provide a library of products without exposing the implementation details
Intended purpose is usually not to create objects | Intended purpose is only to create objects

### Builder
- SRP: The product (burger) does not have to bother with complex construction code.
- Objects can be constructed step-by-step.
