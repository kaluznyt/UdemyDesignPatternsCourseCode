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




