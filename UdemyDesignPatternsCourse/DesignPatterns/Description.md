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



### Composite

Treating individual and aggregate objects uniformly.

##### Motivation
- Object use other objects fields/props/members through inheritance and composition
- composition lets us make compound objects
  - e.g.
    - mathematical expressions composed of simple expressions
    - a grouping of shapes that consist of several shapes
- composite design pattern is used to treat both single (scalar) and composite objects uniformly
  - foo and collection\<foo> have common APIs


*A mechanism for treating individual (scalar) objects and compositions of objects in a uniform manner.*


##### Summary

- Objects can use other objects via inheritance/composition
- Some composed and singular objects need similiar/identical behaviors / APIs
- Composite pattern lets us treat both types of objects uniformly
- C# has special support for the enumeration concept (IEnumerable)
- A single object can masquerade as a collection with yield return this;


### Decorator

Adding behavior without altering the class itself.

##### Motivation
- Want to augment object with additional functionality
- But without changing/rewriting the existing code (OCP)
- And want to keep the new functionality separate (SRP)
- Need to be able to interact with existing structures
- Two options:
  - Inherit from required object if possible, some objects are sealed
  - Build a decorator which references the decorated objects and provides additional behavior


*Faciliates the addition of behaviors to individual objects without inheriting from them*


##### Summary

- A decorator keeps the reference to the decorated objects
- may or may not proxy over calls (or just part of calls)
  - user Resharper to generate delegated members
- exists in a static variation X<Y\<Foo>>
  - very limited use, inability to inherit from type params


### Façade

Exposing several components through a simple interface.

##### Motivation
- Balancing complexity and presentation/usability
- End user is not exposed to internals (may be a complex internal structure that's hidden)


*Provides a simple, easy to understand/user interface over a large and sophisticated body of code.*


##### Summary

- Build a Facade to provide a simplified API over a set of classes
- (optionally) May wish to expose internals through the facade
- May allow users to escalate to user more complex APIs if they want/need to


### Flyweight

Space optimization!

##### Motivation
- Avoid redundancy when storing data
- E.g. MMORPG
  - plenty of users with identical first/last names
  - no sense in storing same first/last name over and over again
  - store a list of names and pointers to them
- .NET performs string interning, so and identical string is stored only once
- bold or italic text in the console
  - dont' want each character to have a formatting character
  - operate on ranges (line number, start/end positions)

*A space optimization technique that lets us use less memory by storing externally the data associated with similiar objects.*

##### Summary

- If you have any data that is common minimize the storage space for that data.
- Define the idea of ranges on homogeneous collections and store data related to those ranges.
- .NET string interning is the Flyweight pattern


### Proxy

An interface for accessing a particular resource.

##### Motivation
- You are making a call foo.Bar()
- This assumes that foo is in the same process as Bar()
- What if later on, you want to put all foo-related operations into a separate process
- proxy to the rescue:
  - same interface, entirely different behavior
  - communication proxy, logging, virtual, guarding...


*A class that functions as an interface to a particular resource.
That resource may be remote, expensive to construct, or may require logging or some other added functionality.*


##### Proxy vs Decorator
- Proxy provides an identical interface, decorator provides an enhanced interface
- Decorator typicaly aggregates or has reference to what it is decorating, proxy doesnt need to
- Proxy might not even be working with a materialized object


##### Summary

- Proxy has the same interface as an underlying object
- To create a proxy simply replicate the existing interface of an object
- Add relevant functionality to the redefined member functions
- Different proxies (communication, logging, caching etc.) have completely different behaviors


### Chain of Responsibility

Sequence of handlers processing an event one after another.

##### Motivation
- Unethical behavior by an employee, who takes a blame ?:
  - Employee, Manager or CEO (example of CoR)
- You click a graphical element on a form
  - Button handles it, stops processing
  - Underlying group box
  - Underlying window 
- Computer game
  - Create has attack and defense values
  - Those can be boosted by other cards
  

*A chain of components who all get a chance to process a command or a query, optionally having default processing implementation and an ability to terminate the processing chain.*


##### Summary

- CoR can be implemented as a chain of references (like linkedlist) or a centralized construct (mediator-like)
- Enlist objects in the chain, possibly controlling their order
- Object removal from chain (e.g. in Dispose())

### Command

YOU SHALL NOT PASS!

##### Motivation
- Ordinary c# statements are perishable
  - cannot undo a field/property assignment
  - cannot directly sreialize a sequence of actions (calls)
- want an object that represents an operation
  - X should change its property Y to Z
  - X should do W()
- Uses: GUI commands, multi-level undo/redo, macro recording and more!


*An object which represents an instruction to perform a particular action. Contains all the information necessary for the action to be taken.*


##### Summary

- Encapsulate all details of an operation in a separate object
- Define instruction for applying the command (either in the command itself or elsewhere)
- Optionally define instructions for undoing the command
- Can create composite commands (aka macros)


### Interpreter

Interpreters are all around us. Even now, in this very room.

##### Motivation
- Textual input needs to be processed
  - E.g. turned into OOP structures
- Some examples:
  - programming language compilers, interpreters and IDEs
  - HTML, XML and similiar
  - Numeric expressions (3+4/5)
  - Regular expressions
- Turning strings into OOP based structures in a complicated process

*A component that processes structured text data. Does so by turning it into separate lexical tokens (lexing) and then interpreting sequences of said tokens (parsing).*

##### Summary

- Barring simple cases, an interpreted acts in two stages
- Lexing turns input into a set of tokens e.g.
  - 3*(4+5) -> Lit[3] Start Lparen Lit[4] Plus Lit[5] Rparen
- Parsing tokens into meaningful constructs (abstract syntax tree):
  - MultiplicationExpression [  
&nbsp;&nbsp;&nbsp;Integer[3],  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AdditionExpression[  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Integer[4],  
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Integer[5]  
&nbsp;&nbsp;]   
]
- Traverse the data and calculate the result


### Iterator

How traversal of data structures happens and who makes it happen.

##### Motivation
- Iteration is a core functinality of various data structures
- An interator is a class that facilitates the traversal
  - keeps a reference to the current element
  - knows how to move to a different element
- Iterator is an implicit construct
  - .NET builds a state machine around your yield return statements


*An object (or in .NET a method) that facilitates the traversal of a data structure*


##### Summary

- An iterator specifies how you can traverse an object
- An iterator object unlike a method cannot be recursive
- Generally, an IEnumerable\<T>-returning method is enough
- Iteration works through duck typing - you need GetEnumerator() that yields a type that has Current and MoveNext()


### TEMPLATE

description

##### Motivation
- some objects are simple and can be created in a single constructor call


*template*


##### Summary

- template
