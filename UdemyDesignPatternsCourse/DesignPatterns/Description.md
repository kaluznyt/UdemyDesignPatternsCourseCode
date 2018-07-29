# Design Patterns

## Builder 

When construction gets a little bit too complex.

Motivation:
- some objects are simple and can be created in a single constructor call
- other objects require a lot of ceremony to create
- having an object with 10 constructor arguments is not productive
- instead opt for piecewise construction
- builder provides an API for step-by-step construction of complex objects 


*When a piecewise object construction is complicated, provide an API for doing it succintly.*


#### Summary

- A builder is a separate component for building an object
- Can either give builder a constructor or return via a static function from a component
- To make builder fluent return this
- Different facets of an object can be build with different builders working in tandem via a base class




## Factory Method & Abstract Factory

*A component responsible solely for the wholesale (not piecewise) creation of objects.*

Motivation:
- object creation logic becomes too convoluted
- constructor is not descriptive
  - name mandated by name of containing type
  - cannot overload with same sets of arguments with different names
  - can turn into 'optional parameter hell'
- object creation (non-piecewise, unlike Builder) can be outsourced to
  - a separate function (factory method)
  - that may exist in a separate class (factory)
  - can create hierarchy of factories with abstract factory

#### Summary

- A factory method is a static method that creates objects
- a factory can take care of object creation
- a factory can be external or reside inside the object as an inner class
- hierarchies of factories can be used to create related objects (abstract factory)


## TEMPLATE

description

Motivation:
- some objects are simple and can be created in a single constructor call


*template*


#### Summary

- template
