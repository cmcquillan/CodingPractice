# Quick Tutorial in ML.NET
The goal is to learn some items of the ML.NET library in a short amount of time and create a quick 'Hello World!' for machine learning.

[Tutorial Link](https://docs.microsoft.com/en-us/dotnet/machine-learning/tutorials/sentiment-analysis)

## Goals
* Perform a quick-and-dirty Machine Learning task
* Get some familiarity with the ML.NET boilerplate
* Get some familiarity with transforming data in ML.NET

## Outcomes
The sentiment analysis tutorial went relatively well. One of the main takeaways when rewriting the code was that I had a column named "PredictionLabel" which was not referenced elsewhere in code. This column was supposed to contain the final prediction for the overall sentiment, but it consistently registered as negative despite statements like "I love this steak". This occurred because the column was mistyped and should have been "PredictedLabel". This name is *also* not referenced anywhere in the code, so it must have been inferred as the output by convention, which was not spelled out during the tutorial. This is a worthwhile thing to look out for in the future.
