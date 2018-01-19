using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepAnalytics2 : MonoBehaviour {

	private const float CompareIsZeroTolerance = 0.000000000001f;
 
	private void ConvertToCV(List<double> data)
	{
		double mean = data.Mean();
		double sd = data.StandardDeviation(); 

		double cv = CoefficientOfVariance(sd, mean);

		Debug.Log("CV: {0}, (mean: {1}, sd: {2})" + cv + mean + sd);
		Debug.Log("Test");
	}
		
	private static double CoefficientOfVariance(double sd, double mean)
	{
		if (Math.Abs(mean - 0) < CompareIsZeroTolerance) return 0;
		return sd / mean;
	}
}

public static class MyListExtensions
{
	public static double Mean(this List<double> values)
	{
		return values.Count == 0 ? 0 : values.Mean(0, values.Count);
	}

	private static double Mean(this IList<double> values, int start, int end)
	{
		double s = 0;

		for (int i = start; i < end; i++)
		{
			s += values[i];
		}

		return s / (end - start);
	}

	private static double Variance(this IList<double> values, double mean, int start, int end)
	{
		double variance = 0;
		int i;
		for (i = start; i < end; i++)
		{
			variance += Math.Pow((values[i] - mean), 2);
		}

		int n = end - start;
		if (start > 0) n -= 1;
		return variance / (n);
	}

	public static double StandardDeviation(this List<double> values)
	{
		return values.Count == 0 ? 0 : values.StandardDeviation(0, values.Count);
	}

	private static double StandardDeviation(this IList<double> values, int start, int end)
	{
		double mean = values.Mean(start, end);
		double variance = values.Variance(mean, start, end);

		return Math.Sqrt(variance);
	}
}
