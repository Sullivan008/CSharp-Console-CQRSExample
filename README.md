# C# - Console CQRS Example Application [Year of Development: 2019]

About the application technologies and operation:

### Technologies:
- Programming Language: C#
- FrontEnd Side: Console Application
- BackEnd Side: .NET Framework 4.6.1.

### Installation/ Configuration:

1. Restore necessary Packages, run the following command in **PM Console**

   ```
   Update-Package -reinstall
   ```
 
### About the application:

**What is CQRS?**

First, let’s tackle at the very core what **CQRS** actually is.

**CQRS** stands for **Command Query Responsibility** Segregation and was coined by Greg Young. **CQRS** is related to **CQS** (**Command Query Separation**) principle by Bertrand Myer which states:

Every method should either be a command that performs an action, or a query that returns data to the caller, but not both.

In other words, a command is a method that mutates state and query is a method that returns state. A method generally doesn’t do both, but there are exceptions to this rule.

**CQRS** takes **CQS** a step further by separating commands and queries into different objects.

The application shows the following:
- How to implement **CQRS Pattern** on a **Person Entity**.
- How to implement **CQRS Pattern** and **Event Sourcing**.
