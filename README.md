```bash
 _        _______           _______  _______  _         
( (    /|(  ____ \|\     /|(  ____ )(  ___  )( \        
|  \  ( || (    \/| )   ( || (    )|| (   ) || (        
|   \ | || (__    | |   | || (____)|| (___) || |        
| (\ \) ||  __)   | |   | ||     __)|  ___  || |        
| | \   || (      | |   | || (\ (   | (   ) || |        
| )  \  || (____/\| (___) || ) \ \__| )   ( || (____/\  
|/    )_)(_______/(_______)|/   \__/|/     \|(_______/  
                                                        
 _        _______ _________          _______  _______  _         
( (    /|(  ____ \\__   __/|\     /|(  ___  )(  ____ )| \    /\  
|  \  ( || (    \/   ) (   | )   ( || (   ) || (    )||  \  / /  
|   \ | || (__       | |   | | _ | || |   | || (____)||  (_/ /   
| (\ \) ||  __)      | |   | |( )| || |   | ||     __)|   _ (    
| | \   || (         | |   | || || || |   | || (\ (   |  ( \ \   
| )  \  || (____/\   | |   | () () || (___) || ) \ \__|  /  \ \  
|/    )_)(_______/   )_(   (_______)(_______)|/   \__/|_/    \/  
                                                                 
 ______   _______ _________ _        _______ _________
(  __  \ (  ___  )\__   __/( (    /|(  ____ \\__   __/
| (  \  )| (   ) |   ) (   |  \  ( || (    \/   ) (   
| |   ) || |   | |   | |   |   \ | || (__       | |   
| |   | || |   | |   | |   | (\ \) ||  __)      | |   
| |   ) || |   | |   | |   | | \   || (         | |   
| (__/  )| (___) |   | |   | )  \  || (____/\   | |   
(______/ (_______)   )_(   |/    )_)(_______/   )_(   
                                                      

```

# Neural Network in C#

This is a simple implementation of a neural network in C#. The neural network uses a single-layer architecture and the backpropagation algorithm to learn and make predictions.

## Prerequisites

- [.NET 7.0](https://dotnet.microsoft.com/en-us/download)

## How to Run

1. Clone this repository to your local machine.

```bash
git clone https://github.com/aakashapoorv/neural-network-dotnet.git
```

2. Open a terminal and navigate to the project's root directory.

3. Compile and run the program using the following command:

```bash
dotnet run
```

4. The program will print the initial synaptic weights, perform 10,000 iterations of training, and finally print the synaptic weights after training, as well as the output after training.

## Neural Network Details

- Sigmoid Function: The sigmoid function is used to normalize the inputs.

- Sigmoid Derivative: The sigmoid derivative is used to adjust the synaptic weights during training.

- Training Inputs and Outputs: The input and output datasets are provided in the `trainingInputs` and `trainingOutputs` arrays, respectively.

- Synaptic Weights: The weights of the neural network are initialized randomly with mean 0 and stored in the `synapticWeights` array.

- Training: The neural network is trained using the backpropagation algorithm for 10,000 iterations.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.