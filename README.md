The task will be to perform a task a quickly as possible.

There are 10 000 objects in a list.

Each object must have 2 steps performed on it.

### The object:

    public class Work
    {
        public Guid Id { get; }

        public string Step1Result { get; set; }

        public string Step2Result { get; set; }

        public Work()
        {
            Id = Guid.NewGuid();
        }
    }
### The first step:
-	Order the Id, and set on Step1Result property
### The second step:
-	Sum all numbers in the Id, and set on Step2Result property
### Additional Requirements:
-	The Work class cannot be modified.
-	The Work results need to be written to a UI/Console once it is complete, this is to validate the results.
  - The writing to UI/Console should not be timed.


Simple right? . . . ¯\\_(ツ)_/¯
