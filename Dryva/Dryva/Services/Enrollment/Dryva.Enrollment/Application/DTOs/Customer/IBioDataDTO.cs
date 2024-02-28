namespace Dryva.Enrollment.DTOs
{
    /// <summary>
    /// Represents the bio data DTO interface.
    /// </summary>
    public interface IBioDataDTO
    {
        /// <summary>
        /// Gets or sets the left index image.
        /// </summary>
        /// <value>The left index image.</value>
        byte[] LeftIndexImage { get; set; }
        /// <summary>
        /// Gets or sets the left index minutia.
        /// </summary>
        /// <value>The left index minutia.</value>
        byte[] LeftIndexMinutia { get; set; }
        /// <summary>
        /// Gets or sets the left thumb image.
        /// </summary>
        /// <value>The left thumb image.</value>
        byte[] LeftThumbImage { get; set; }
        /// <summary>
        /// Gets or sets the left thumb minutia.
        /// </summary>
        /// <value>The left thumb minutia.</value>
        byte[] LeftThumbMinutia { get; set; }
        /// <summary>
        /// Gets or sets the photograph.
        /// </summary>
        /// <value>The photograph.</value>
        byte[] Photograph { get; set; }
        /// <summary>
        /// Gets or sets the right index image.
        /// </summary>
        /// <value>The right index image.</value>
        byte[] RightIndexImage { get; set; }
        /// <summary>
        /// Gets or sets the right index minutia.
        /// </summary>
        /// <value>The right index minutia.</value>
        byte[] RightIndexMinutia { get; set; }
        /// <summary>
        /// Gets or sets the right thumb image.
        /// </summary>
        /// <value>The right thumb image.</value>
        byte[] RightThumbImage { get; set; }
        /// <summary>
        /// Gets or sets the right thumb minutia.
        /// </summary>
        /// <value>The right thumb minutia.</value>
        byte[] RightThumbMinutia { get; set; }
        /// <summary>
        /// Gets or sets the signature.
        /// </summary>
        /// <value>The signature.</value>
        byte[] Signature { get; set; }
    }
}