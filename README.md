# HoltsmarkDistribution
 
In probability theory, the Holtsmark distribution is a probability distribution named after Johan Peter Holtsmark, In 1919.  
It's especially used in astrophysics for modeling gravitational bodies.  

This distribution is a special case of a stable distribution with shape parameter &alpha; = 3/2 and skewness parameter &beta; = 0.  

Such a distribution with &beta; = 0 is called symmetric alpha-stable distribution.  
- &alpha; = 2: Normal distribution
- &alpha; = 1: Cauchy distribution

The Holtsmark distribution, like these distribution, has a closed-from expression, but it can't be expressed in terms of elementary function.  

![pdf](figures/holtsmark_pdf.svg)  
![pdf-loglog](figures/holtsmark_pdf_loglog.svg)  
![cdf](figures/holtsmark_cdf.svg)  

## Definition
The Holtsmark distribution, generalized to a stable distribution by introducing position and scale parameters, is as follows:  
![holtsmark1](figures/holtsmark1.svg)  

Since scaling and translations allow for standardization, standard parameters are discussed here.  
![holtsmark2](figures/holtsmark2.svg)  
![holtsmark3](figures/holtsmark3.svg)  

## Numerical Evaluation
Using hypergeometric function, it's obtained as follows:  
![holtsmark4](figures/holtsmark4.svg)  

The following series expression can also be used:  
![holtsmark5](figures/holtsmark5.svg)  

When x is large, the following equation can be used as an asymptotic expression:  
![holtsmark6](figures/holtsmark6.svg)  

Evaluating only one term of this equation yields the tail power of the distribution:  
![holtsmark7](figures/holtsmark7.svg)  

## Numeric Table
[PDF Precision 150](results/pdf_precision150.csv)  
[CDF Precision 150](results/cdf_precision150.csv)  

## S&alpha;S Distributions
![sass-pdf](figures/sass_pdf.svg)  
![sass-pdf-loglog](figures/sass_pdf_loglog.svg)  

## Reference
[J.Holtsmark, "Uber die Verbreiterung von Spektrallinien" (1919)](https://zenodo.org/records/1424343)  
[J.C.Pain "Expression of the Holtsmark function in terms of hypergeometric 2F2 and Airy Bi functions" (2010)](https://arxiv.org/abs/2001.11893)  