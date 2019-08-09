# modernizelegacycode

Note that the ResultController is coupled tightly with Manager class.
To start the decoupling, the first step is to move the initialization to constructor. 

Later one for unit testing, we have to mimic the behavior of manager. So we will need an interface. So we can go ahead and create an interface for Manager.
Once that is done, we create a private variable of type IManager. and create a default constructor where _manager is initialized with a new instance of Manager. If we fail to do this, the existing code will fail.

We create another constructor in which we inject the dependency via constructor.

With these changes, the GetResults method is free from dependency to the behavior of the _manager. This can be provided at initialization step.
The rest of the flow does not need to change.

Now going back to Manager, we have a tight coupling with ResultsRepository() in the GetResultList method. We can take the similar steps that we took in Controller class to manage the dependency.

- We will create an interface for ResultsRepository and make ResultsRepository implement the interface.

Now we will test these changes. I used Advanced Rest Client to test this.
