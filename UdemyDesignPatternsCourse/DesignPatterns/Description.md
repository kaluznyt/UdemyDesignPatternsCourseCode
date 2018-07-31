# Design Patterns

## Creational


### Builder 

When construction gets a little bit too complex.

##### Motivation
- some objects are simple and can be created in a single constructor call
- other objects require a lot of ceremony to create
- having an object with 10 constructor arguments is not productive
- instead opt for piecewise construction
- builder provides an API for step-by-step construction of complex objects 


*When a piecewise object construction is complicated, provide an API for doing it succintly.*


##### Summary

- A builder is a separate component for building an object
- Can either give builder a constructor or return via a static function from a component
- To make builder fluent return this
- Different facets of an object can be build with different builders working in tandem via a base class

### Factory Method & Abstract Factory

*A component responsible solely for the wholesale (not piecewise) creation of objects.*

##### Motivation
- object creation logic becomes too convoluted
- constructor is not descriptive
  - name mandated by name of containing type
  - cannot overload with same sets of arguments with different names
  - can turn into 'optional parameter hell'
- object creation (non-piecewise, unlike Builder) can be outsourced to
  - a separate function (factory method)
  - that may exist in a separate class (factory)
  - can create hierarchy of factories with abstract factory

##### Summary

- A factory method is a static method that creates objects
- a factory can take care of object creation
- a factory can be external or reside inside the object as an inner class
- hierarchies of factories can be used to create related objects (abstract factory)

### Prototype

When it's easier to copy an existing object to fully initialize a new one.

##### Motivation
- complicated objects (ex. cars) aren't designed from scratch all the time
  - it's an iterative process
- an existing (partially or fully constructed) design is a Prototype
- we make a copy (clone) the prototype and customize it
  - requires 'deep copy' support
- make cloning convenient


*A partially or fully initialized object that you copy (clone) and make use of*


##### Summary

- To implement a prototype, partially construct an object and store it somewhere
- Clone the prototype
  - Implement deep copy yourself via copy constructors, interfaces etc.
  - serialize, deserialize using existing serializer
- Customize the resulting instance


### Singleton

A design pattern everyone loves to hate..but is it really that bad ?

*"When discussing whith patterns to drop, we found that we still love them all. (Not really - I'm in favor of dropping Singleton. Its use is almost always a design smell.)"*  

*Erich Gamma*

##### Motivation
- for some components it only make sense to have one instance in the system
  - database repository
  - object factory
- where constructor call is expensive
  - we do it only once
  - we provide everyone with the same instance
- want to prevent anyone creating additional copies
- need to take care of lazy instantiation and thread safety

*A component whith is instantiated only once*

##### Summary

- Making a safe singleton is easy: construct a static Lazy< T> and return it's Value
- Thread safe implementation needs more work
- Singletons are difficult to test
- Instead of directly using a singleton, consider depending on a abstraction (e.g. interface)
- consider defining singleton lifetime in DI container

## Structural

### Adapter

Getting the interface you want from the interface you have.

A construct whith adapts an existing interface X to conform to the required interface Y.


##### Summary

- Implementing an Adapter is easy
- Determine the API you have and the API you need to provide
- Create a component which aggregates the adapteee
- Intermediate representations can pile up: use caching and other optimizations

### Bridge

Connecting components together through abstractions.

##### Motivation
- Bridge prevents a 'Cartesian product' complexity explosion
  - Example:
    - Base class ThreadScheduler
      - Can be preemptive or cooperative
      - Can run on Windows or Linux
      - Ends up with a 2 x 2 scenario: WindowsPTS, UnixPTS, WindowsCTS, UnixCTS..
- Bridge avoids entity explosion


*A mechanism that decouples an interface (hierarchy) from an implementation (hierarchy)*

##### Summary

- Decouple abstraction from implementation
- Both can exist as hierarchies
- A stronger form of encapsulation


### TEMPLATE

description

##### Motivation
- some objects are simple and can be created in a single constructor call


*template*


##### Summary

- template
