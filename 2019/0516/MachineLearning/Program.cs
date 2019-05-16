using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using static Microsoft.ML.DataOperationsCatalog;

namespace MachineLearning
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataPath = Path.Combine(Environment.CurrentDirectory, "data", "yelp_labelled.txt");
            string outPath = Path.Combine(Environment.CurrentDirectory, "data", "Model.zip");

            Console.WriteLine(dataPath);
            Console.WriteLine(outPath);

            MLContext mlContext = new MLContext();

            TrainTestData dataView = LoadData(mlContext, dataPath);
            ITransformer model = BuildAndTrain(mlContext, dataView.TrainSet);
            Evaluate(mlContext, model, dataView.TestSet);
            UseModelWithSingleItem(mlContext, model);
            UseModelWithBatchItems(mlContext, model);
            UseModelWithUserInput(mlContext, model);
        }

        private static void UseModelWithUserInput(MLContext mlContext, ITransformer model)
        {
            var predictionEngine = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
            Console.WriteLine("=============== Beginning User Input Tests ===============");

            while (true)
            {
                Console.Write("Please give me a statement to evaluate: ");
                var sentiment = new SentimentData
                {
                    SentimentText = Console.ReadLine()
                };

                var result = predictionEngine.Predict(sentiment);
                WriteResult(result);
            }
        }

        public static void UseModelWithBatchItems(MLContext mlContext, ITransformer model)
        {
            IEnumerable<SentimentData> sentiments = new[]
            {
                new SentimentData
                {
                    SentimentText = "This was a horrible meal"
                },
                new SentimentData
                {
                    SentimentText = "I love this spaghetti."
                }
            };

            IDataView batch = mlContext.Data.LoadFromEnumerable(sentiments);
            IDataView predictions = model.Transform(batch);
            IEnumerable<SentimentPrediction> results = mlContext.Data.CreateEnumerable<SentimentPrediction>(predictions, reuseRowObject: false);

            Console.WriteLine();
            Console.WriteLine("=============== Prediction Test of loaded model with multiple samples ===============");
            foreach (SentimentPrediction prediction in results)
            {
                Console.WriteLine($"Sentiment: {prediction.SentimentText} | Prediction: {(Convert.ToBoolean(prediction.Prediction) ? "Positive" : "Negative")} | Probability: {prediction.Probability} ");

            }
            Console.WriteLine("=============== End of predictions ===============");
        }

        private static void UseModelWithSingleItem(MLContext mlContext, ITransformer model)
        {
            PredictionEngine<SentimentData, SentimentPrediction> predictionFunction = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
            SentimentData sample = new SentimentData
            {
                SentimentText = "This was a very bad steak"
            };

            var result = predictionFunction.Predict(sample);

            Console.WriteLine();
            Console.WriteLine("==== Prediction Test of model with a single sample and test dataset ===============");

            WriteResult(result);

            Console.WriteLine("==== End of Predictions ===============");
            Console.WriteLine();
        }

        private static void WriteResult(SentimentPrediction result)
        {
            Console.WriteLine();
            Console.WriteLine($"Sentiment: {result.SentimentText} | Prediction: {(Convert.ToBoolean(result.Prediction) ? "Positive" : "Negative")} | Probability: {result.Probability} ");
        }

        public static void Evaluate(MLContext mlContext, ITransformer model, IDataView splitTestSet)
        {
            Console.WriteLine("==== EVALUATING MODEL ======================");
            IDataView predictions = model.Transform(splitTestSet);
            CalibratedBinaryClassificationMetrics metrics = mlContext.BinaryClassification.Evaluate(predictions, "Label");

            Console.WriteLine();
            Console.WriteLine("Model quality metrics evaluation");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($"Auc: {metrics.AreaUnderRocCurve:P2}");
            Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
            Console.WriteLine("==== END EVALUATION ========================");
        }

        private static ITransformer BuildAndTrain(MLContext mlContext, IDataView trainSet)
        {
            var estimator = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentData.SentimentText))
                .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                    labelColumnName: "Label",
                    featureColumnName: "Features"
                ));
            Console.WriteLine("==== MODEL CREATED =======================");
            var model = estimator.Fit(trainSet);
            Console.WriteLine("==== END TRAINING ========================");
            Console.WriteLine();

            return model;
        }

        private static TrainTestData LoadData(MLContext mlContext, string dataPath)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentData>(dataPath, hasHeader: false);
            TrainTestData splitView = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);

            return splitView;
        }
    }
}
